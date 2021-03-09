using DataModel;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public class RegistrationObserver:IRegisrtationObserver
    {
        private RegistrarsModelMapper modelMapper;
        List<RegistrarsDataModel> registrars;

        public RegistrationObserver()
        {
            modelMapper = new RegistrarsModelMapper();
            registrars = new List<RegistrarsDataModel>();
        }

        public void AddRegistrar(RegistrarsDataModel registrar)

        {
            registrars.Add(registrar);

        }

        public void RemoveRegistrar(RegistrarsDataModel registrar)
        {
            registrars.Remove(registrar);
        }

        public void NotifyRegistrar(List<RegistrarsDataModel> registrars)
        {

        }
    }
}
