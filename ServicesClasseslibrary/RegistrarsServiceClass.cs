using DataModel;
using DataRepository.GateWay;
using DataRepository.ModelMappers;
using DataRepository.ModelMappers.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public class RegistrarsServiceClass: IRegistrarServiceClass
    {
        private IRegistrarsModelMapper modelMapper;
        public RegistrarsServiceClass()
        {
            // settingsModelMapper = new SystemSettingsModelMapper();

        }
        public RegistrarsServiceClass(IRegistrarsModelMapper registrarsModelMapper)
        {
            modelMapper = registrarsModelMapper;

        }
        public void AddRegistrar(RegistrarsDataModel registrar)
        {
            modelMapper.AddRegistrar(registrar);

        }
        public void EditRegistrar(RegistrarsDataModel registrar)
        {
            

            modelMapper.Edit(registrar);
        }
       
        public void MarkRegistrarsAsnotified(RegistrarsDataModel registrar)
        {
            registrar.Notified = true;
            modelMapper.Notify(registrar);
               
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
