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
        List<VaccinationReservationDataModel> VaccinationReservations;

        public RegistrationObserver()
        {
            modelMapper = new RegistrarsModelMapper();
            VaccinationReservations = new List<VaccinationReservationDataModel>();
        }

        public void AddRegistrar(VaccinationReservationDataModel registrar)

        {
            VaccinationReservations.Add(registrar);

        }
        public void AddRegistrars(List<VaccinationReservationDataModel> pvaccinationReservations)

        {
            VaccinationReservations.AddRange(pvaccinationReservations);
            NotifyRegistrar(pvaccinationReservations);

        }

        public void RemoveRegistrar(VaccinationReservationDataModel registrar)
        {
            VaccinationReservations.Remove(registrar);
        }

        private void NotifyRegistrar(List<VaccinationReservationDataModel> registrars)
        {

        }
    }
}
