using DataRepository.DataRepositoryEntities;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.GateWay
{
    public interface IContextGateWay
    {
        public RepositoryGateWay<VaccinationTypesRepository> VaccinationTypes { get; set; }

        public RepositoryGateWay<RegistrarsRepository> Registrars { get; set; }

        public RepositoryGateWay<SystemSettingsRepository> SystemSettings { get; set; }


        public void CreateDatabaseTransaction();



        public void Rollback();

        public void Dispose();
        public void Commit();
    }
}
