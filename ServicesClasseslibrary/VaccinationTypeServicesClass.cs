using DataModel;
using DataRepository;
using System;
using DataRepository.GateWay;
using System.Collections.Generic;
using DataRepository.ModelMappers;
using DataRepository.ModelMappers.Interface;

namespace ServicesClasseslibrary
{
    public class VaccinationTypeServicesClass: IVaccinationTypeServicesClass
    {
        private IVaccinationTypesModelMapper modelMapper;
        public VaccinationTypeServicesClass()
        {
          

        }
        public VaccinationTypeServicesClass(IVaccinationTypesModelMapper iVaccinationTypesModelMapper)
        {
            modelMapper = iVaccinationTypesModelMapper;

        }

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
