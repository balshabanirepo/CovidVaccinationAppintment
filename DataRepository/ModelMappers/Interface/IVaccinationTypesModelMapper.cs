using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.ModelMappers.Interface
{
   public interface IVaccinationTypesModelMapper
    {
        void AddVaccinationType(VaccinationTypesDataModel model);
        void Edit(VaccinationTypesDataModel model);

        void Delete(int id);

        VaccinationTypesDataModel GetById(int id);

        List<VaccinationTypesDataModel> list();

    }
}
