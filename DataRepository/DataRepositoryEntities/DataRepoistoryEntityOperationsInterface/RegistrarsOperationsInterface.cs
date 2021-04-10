using DataModel;
using DataRepository.DataRepositoryEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Interface.DataRepoistoryEntityOperationsInterface
{
   public interface RegistrarsOperationsInterface
    {
        void AddRegistrar(RegistrarsDataModel Registrars);
        void Edit(RegistrarsDataModel model);

        void Notify(RegistrarsDataModel model);

        void Delete(int id);


        RegistrarsDataModel GetById(int id);

        List<RegistrarsDataModel> list();
    }
}
