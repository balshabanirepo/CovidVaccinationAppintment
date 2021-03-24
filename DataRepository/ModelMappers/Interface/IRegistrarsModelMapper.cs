using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.ModelMappers.Interface
{
    public interface IRegistrarsModelMapper
    {
        void AddRegistrar(RegistrarsDataModel model);
        void Edit(RegistrarsDataModel model);
        void Notify(RegistrarsDataModel model);
        void Delete(int id);

        RegistrarsDataModel GetById(int id);

        List<RegistrarsDataModel> list();

       

    }
}
