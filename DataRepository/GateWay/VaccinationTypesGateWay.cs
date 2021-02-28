using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.GateWay
{
   public class VaccinationTypesGateWay:DataBaseGateWay
    {
        public void AddVaccinationType(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            
            vaccinationTypes.Name = model.Name;
            Add(vaccinationTypes);

        }

        public void Edit(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            vaccinationTypes.Id = model.Id;
            vaccinationTypes.Name = model.Name;
            Add(vaccinationTypes);

        }

        public void Delete(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            vaccinationTypes.Id = model.Id;

            Delete(vaccinationTypes);

        }

        public override  List<object> List()
        {
            VaccinationTypesRepository repository = new VaccinationTypesRepository();

            dbConext.e(repository.GetType().ToString()).tol
        }
    }
}
