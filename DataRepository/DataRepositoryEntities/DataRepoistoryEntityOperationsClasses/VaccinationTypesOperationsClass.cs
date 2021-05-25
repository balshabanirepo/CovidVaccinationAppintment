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
        //RepositoryGateWay<VaccinationTypesRepository> dataBaseGateWay;
        IContextGateWay gateway;
        public VaccinationTypesOperationsClass(IContextGateWay contextGateWay )
        {
            // dataBaseGateWay = new RepositoryGateWay<VaccinationTypesRepository>();
            gateway = contextGateWay;
            //ContextGateway.GetContextInstance();
        }


        public void AddVaccinationTypes(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository VaccinationType = new VaccinationTypesRepository();

            VaccinationType.Id = model.Id;
            VaccinationType.Name = model.Name;
            gateway.VaccinationTypes.Add(VaccinationType);
           // dataBaseGateWay.Add(VaccinationType);

        }

        public void Edit(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository VaccinationType = new VaccinationTypesRepository();
            VaccinationTypesRepository VaccinationTypeStoredInDb = gateway.VaccinationTypes.GetById(g => g.Id == model.Id);
            VaccinationType.Id = model.Id;
            VaccinationType.Name = model.Name;
            gateway.VaccinationTypes.Edit(VaccinationTypeStoredInDb, VaccinationType);
           
        }

        public void Delete(int id)
        {

            VaccinationTypesRepository VaccinationType = gateway.VaccinationTypes.GetById(c => c.Id == id);
            gateway.VaccinationTypes.Delete(VaccinationType);

        }

        public VaccinationTypesDataModel GetById(int id)
        {


            VaccinationTypesRepository VaccinationType = gateway.VaccinationTypes.GetById(c => c.Id == id);

            return new VaccinationTypesDataModel { Id = VaccinationType.Id, Name = VaccinationType.Name };


        }

        public List<VaccinationTypesDataModel> list()
        {


            List<VaccinationTypesRepository> VaccinationTypeRepositories = gateway.VaccinationTypes.List();
            return (from r in VaccinationTypeRepositories
                    select new VaccinationTypesDataModel
                    {
                        Id = r.Id,
                        Name = r.Name,

                    }).ToList();

        }
    }
}
