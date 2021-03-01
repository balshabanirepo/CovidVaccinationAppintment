using DataModel;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public class RegistrarsServiceClass:IserviceClass
    {
        private RegistrarsModelMapper modelMapper = new RegistrarsModelMapper();

        public void AddRegistrar(RegistrarsDataModel vaccination)
        {
            modelMapper.AddRegistrar(vaccination);

        }
        public void EditRegistrar(RegistrarsDataModel vaccination)
        {
            modelMapper.Edit(vaccination);
        }
        public void DeleteRegistrar(int id)
        {
            modelMapper.Delete(id);
        }
        public List<RegistrarsDataModel> List()
        {
            return modelMapper.list();



        }
        public RegistrarsDataModel GetById(int id)
        {
            return modelMapper.GetById(id);

        }

    }
}
