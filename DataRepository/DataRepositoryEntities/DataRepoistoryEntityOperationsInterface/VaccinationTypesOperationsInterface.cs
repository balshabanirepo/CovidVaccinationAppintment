using DataModel;
using DataRepository.DataRepositoryEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Interface.DataRepoistoryEntityOperationsInterface
{
   public interface VaccinationTypesOperationsInterface
    {
        public void AddVaccinationTypes(VaccinationTypesDataModel model);
        void Edit(VaccinationTypesDataModel model);



        void Delete(int id);


        VaccinationTypesDataModel GetById(int id);

        List<VaccinationTypesDataModel> list();
    }
}
