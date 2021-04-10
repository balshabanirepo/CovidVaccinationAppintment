using DataModel;
using DataRepository.GateWay;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses
{
        public class VaccinationTypesOperationsClass : VaccinationTypesOperationsInterface
 
    {
        RepositoryGateWay<VaccinationTypesRepository> dataBaseGateWay;
        public VaccinationTypesOperationsClass()
        {
            dataBaseGateWay = new RepositoryGateWay<VaccinationTypesRepository>();
        }


        public void AddVaccinationTypes(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository VaccinationType = new VaccinationTypesRepository();

            VaccinationType.Id = model.Id;
            VaccinationType.Name = model.Name;

            dataBaseGateWay.Add(VaccinationType);

        }

        public void Edit(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository VaccinationType = new VaccinationTypesRepository();
            VaccinationTypesRepository VaccinationTypeStoredInDb = dataBaseGateWay.GetById(g => g.Id == model.Id);
            VaccinationType.Id = model.Id;
            VaccinationType.Name = model.Name;
           
            dataBaseGateWay.Edit(VaccinationTypeStoredInDb, VaccinationType);
        }

        public void Delete(int id)
        {

            VaccinationTypesRepository VaccinationType = dataBaseGateWay.GetById(c => c.Id == id);
            dataBaseGateWay.Delete(VaccinationType);

        }

        public VaccinationTypesDataModel GetById(int id)
        {


            VaccinationTypesRepository VaccinationType = dataBaseGateWay.GetById(c => c.Id == id);

            return new VaccinationTypesDataModel { Id = VaccinationType.Id, Name = VaccinationType.Name };


        }

        public List<VaccinationTypesDataModel> list()
        {


            List<VaccinationTypesRepository> VaccinationTypeRepositories = dataBaseGateWay.List();
            return (from r in VaccinationTypeRepositories
                    select new VaccinationTypesDataModel
                    {
                        Id = r.Id,
                        Name = r.Name,

                    }).ToList();

        }
    }
}
