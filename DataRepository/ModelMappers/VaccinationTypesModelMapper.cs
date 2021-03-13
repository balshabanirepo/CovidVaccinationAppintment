using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.GateWay
{
   public class VaccinationTypesModelMapper
    {
         RepositoryGateWay<VaccinationTypesRepository> dataBaseGateWay;
        public VaccinationTypesModelMapper()
             {
                dataBaseGateWay = new RepositoryGateWay<VaccinationTypesRepository>();

             }
        public void AddVaccinationType(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            
            vaccinationTypes.Name = model.Name;
            dataBaseGateWay.Add(vaccinationTypes);

        }

        public void Edit(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            VaccinationTypesRepository vaccinationTypesStoredInDb = dataBaseGateWay.GetById(g => g.Id == model.Id);
            vaccinationTypes.Id = model.Id;
            vaccinationTypes.Name = model.Name;
            dataBaseGateWay.Edit(vaccinationTypesStoredInDb,vaccinationTypes);
        }

        public void Delete(int id)
        {
            VaccinationTypesRepository vaccinationTypes;
            vaccinationTypes= dataBaseGateWay.GetById(c=>c.Id==id);
            dataBaseGateWay.Delete(vaccinationTypes);

        }

        public VaccinationTypesDataModel GetById(int id)
        {
            VaccinationTypesRepository vaccinationTypes  ;

            vaccinationTypes= dataBaseGateWay.GetById(c=>c.Id==id);
            return new VaccinationTypesDataModel
            {
                Id= vaccinationTypes.Id,
                Name=vaccinationTypes.Name
            };

        }

        public List<VaccinationTypesDataModel> list()
        {
            

           List<VaccinationTypesRepository> vaccinationTypesRepositories= dataBaseGateWay.List();
            return (from r in vaccinationTypesRepositories
                    select new VaccinationTypesDataModel
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();

        }


    }
}
