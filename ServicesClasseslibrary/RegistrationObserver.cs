using DataModel;
using DataRepository.GateWay;
using DataRepository.ModelMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
   public class RegistrationObserver:IRegisrtationObserver
    {
        private RegistrarsModelMapper modelMapper;
        List<VaccinationReservationDataModel> VaccinationReservations;
        private readonly ISystemSettingsServiceClass _systemSettingsServiceClass;
    
        public RegistrationObserver(ISystemSettingsServiceClass systemSettingsServiceClass)
        {

            _systemSettingsServiceClass = systemSettingsServiceClass;
        }

        public void AddRegistrar(VaccinationReservationDataModel registrar)

        {
            VaccinationReservations.Add(registrar);

        }
        public string AddRegistrars(List<VaccinationReservationDataModel> pvaccinationReservations)

        {
            VaccinationReservations.AddRange(pvaccinationReservations);
            return NotifyRegistrar(pvaccinationReservations);
              

        }

        public void RemoveRegistrar(VaccinationReservationDataModel registrar)
        {
            VaccinationReservations.Remove(registrar);
        }

        private string NotifyRegistrar(List<VaccinationReservationDataModel> VaccinationReservatitions)
        {

            


            Inotifier notifier;
            SystemSettingsDataModel systemSettings;
            //SystemSettingsServiceClass settingsServiceClass = new SystemSettingsServiceClass();
             systemSettings = _systemSettingsServiceClass.GetSystemSettings();
            if(systemSettings!=null)
            {
                if (systemSettings.NotificationType == 1)
                {
                    notifier = new NotifierByPhone();
                }
                else
                {
                    notifier = new NotifyByEmail();
                }
                return notifier.Notify();
            }
            return "no system settings found";
            
        }
    }
}
