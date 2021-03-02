using DataModel;
using DataRepository;
using System;
using DataRepository.GateWay;
using System.Collections.Generic;

namespace ServicesClasseslibrary
{
    public class VaccinationTypeServicesClass: IVaccinationTypeServicesClass
    {
        private VaccinationTypesModelMapper modelMapper = new VaccinationTypesModelMapper();

        public void AddVaccinationType(VaccinationTypesDataModel vaccination)
        {
            modelMapper.AddVaccinationType(vaccination);

        }
        public void EditVaccinationType(VaccinationTypesDataModel vaccination)
        {
            modelMapper.Edit(vaccination);
        }
        public void DeleteVaccinationType(int id    )
        {
            modelMapper.Delete(id);
        }
        public List<VaccinationTypesDataModel> List()
        {
           return modelMapper.list();
          


        }
        public VaccinationTypesDataModel GetById(int id)
        {
            return modelMapper.GetById(id);

        }
    }
}
