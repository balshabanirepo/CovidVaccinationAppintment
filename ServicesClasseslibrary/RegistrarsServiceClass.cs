using DataModel;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public class RegistrarsServiceClass: IRegistrarServiceClass
    {
        private RegistrarsModelMapper modelMapper = new RegistrarsModelMapper();

        public void AddRegistrar(RegistrarsDataModel registrar)
        {
            modelMapper.AddRegistrar(registrar);

        }
        public void EditRegistrar(RegistrarsDataModel registrar)
        {
            modelMapper.Edit(registrar);
        }
      
        public List<RegistrarsDataModel> List()
        {
            return modelMapper.list();



        }
        public void DeleteRegistrars(int Id)
        {
            modelMapper.Delete(Id);
        }
        public RegistrarsDataModel GetById(int id)
        {
            return modelMapper.GetById(id);

        }

    }
}
