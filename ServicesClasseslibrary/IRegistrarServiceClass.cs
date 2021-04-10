using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public interface IRegistrarServiceClass
    {
        public void AddRegistrar(RegistrarsDataModel registrar);

        public void EditRegistrar(RegistrarsDataModel registrar);
        public void MarkRegistrarsAsnotified(RegistrarsDataModel registrar);
        public List<RegistrarsDataModel> List();

        public void DeleteRegistrars(int Id);

        public RegistrarsDataModel GetById(int id);


    }
}
