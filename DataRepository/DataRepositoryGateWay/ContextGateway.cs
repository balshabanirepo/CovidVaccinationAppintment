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
   internal class ContextGateway
    {
        private static DbConext dbConext;
        public  RepositoryGateWay<VaccinationTypesRepository> VaccinationTypes { get; set; }

        public  RepositoryGateWay<RegistrarsRepository> Registrars { get; set; }

        public RepositoryGateWay<SystemSettingsRepository> SystemSettings { get; set; }

        public ContextGateway()
        {
            VaccinationTypes = new RepositoryGateWay<VaccinationTypesRepository>();
            Registrars = new RepositoryGateWay<RegistrarsRepository>();
            SystemSettings= new RepositoryGateWay<SystemSettingsRepository>();
        }
      
        internal static DbConext GetContextInstance()
        {
            if (dbConext == null)
            {
                dbConext = new DbConext();
            }
           return dbConext;
        }

        //private ContextGateway() { }

       
        private static IDbContextTransaction _transaction;



        public static void CreateDatabaseTransaction()
        {
            GetContextInstance();
            _transaction = dbConext.Database.BeginTransaction();
        }



        public static void Rollback()
        {
            _transaction.Rollback();
        }

        public static  void Dispose()
        {
            _transaction.Dispose();
        }

        public static void Commit()
        {
            _transaction.Commit();
        }
    }
}
