using DataModel;
using DataRepository;
using System;
using DataRepository.GateWay;
using System.Collections.Generic;

namespace ServicesClasseslibrary
{
    public class VaccinationTypeServicesClass
    {
        private VaccinationTypesGateWay vaccinationTypesGateWay = new VaccinationTypesGateWay();

        public void AddVaccinationType(VaccinationTypesDataModel vaccination)
        {
            vaccinationTypesGateWay.AddVaccinationType(vaccination);

        }
        public void EditVaccinationType()
        {

        }
        public void DeleteVaccinationType()
        {

        }
        public List<object> List()
        {
           return vaccinationTypesGateWay.List();



        }
    }
}
