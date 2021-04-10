using DataModel;
using DataRepository.GateWay;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public class RegistrarsServiceClass: IRegistrarServiceClass
    {
        //private RegistrarsModelMapper modelMapper = new RegistrarsModelMapper();
        private readonly RegistrarsOperationsInterface _registrarsOperations;

        public RegistrarsServiceClass(RegistrarsOperationsInterface registrarsOperations)
        {
            _registrarsOperations = registrarsOperations;
        }
        public void AddRegistrar(RegistrarsDataModel registrar)
        {
            //modelMapper.AddRegistrar(registrar);
            _registrarsOperations.AddRegistrar(registrar);

        }
        public void EditRegistrar(RegistrarsDataModel registrar)
        {


            // modelMapper.Edit(registrar);
            _registrarsOperations.Edit(registrar);
        }
       
        public void MarkRegistrarsAsnotified(RegistrarsDataModel registrar)
        {
            registrar.Notified = true;
            _registrarsOperations.Notify(registrar);
            // modelMapper.Notify(registrar);

        }
      
        public List<RegistrarsDataModel> List()
        {
            // return modelMapper.list();
            return _registrarsOperations.list();



        }
        public void DeleteRegistrars(int Id)
        {
           // modelMapper.Delete(Id);
        }
        public RegistrarsDataModel GetById(int id)
        {
            //return modelMapper.GetById(id);
            return _registrarsOperations.GetById(id);

        }

    }
}
