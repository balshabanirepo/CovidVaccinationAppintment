using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public interface IVaccinationTypeServicesClass 
    {
        public void AddVaccinationTypes(VaccinationTypesDataModel vaccination);

        public void Edit(VaccinationTypesDataModel vaccination);
        public void Delete(int id);

        public List<VaccinationTypesDataModel> list();

        public VaccinationTypesDataModel GetById(int id);
    }
}
