using DataRepository.DataRepositoryEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataRepository.GateWay
{
   public class ContextGateway: IContextGateWay
    {
       
        public  RepositoryGateWay<VaccinationTypesRepository> VaccinationTypes { get; set; }

        public  RepositoryGateWay<RegistrarsRepository> Registrars { get; set; }

        public RepositoryGateWay<SystemSettingsRepository> SystemSettings { get; set; }
        private static DbConext dbConext;
        public ContextGateway()
        {
            VaccinationTypes = new RepositoryGateWay<VaccinationTypesRepository>();
            Registrars = new RepositoryGateWay<RegistrarsRepository>();
            SystemSettings= new RepositoryGateWay<SystemSettingsRepository>();
           
        }
       
      

        //private ContextGateway() { }

       
        private static IDbContextTransaction _transaction;



        public  void CreateDatabaseTransaction()
        {
            dbConext = DbConext.GetContextInstance();
            _transaction = dbConext.Database.BeginTransaction();
        }



        public  void Rollback()
        {
            _transaction.Rollback();
        }

        public   void Dispose()
        {
            _transaction.Dispose();
        }

        public  void Commit()
        {
            _transaction.Commit();

        }
    }
}
