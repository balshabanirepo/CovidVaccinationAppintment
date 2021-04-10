using DataModel;
using DataRepository;
using System;
using DataRepository.GateWay;
using System.Collections.Generic;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using DevExpress.DirectX.StandardInterop.Direct2D;

namespace ServicesClasseslibrary
{
    public class VaccinationTypeServicesClass: IVaccinationTypeServicesClass
    {
        // private VaccinationTypesModelMapper modelMapper = new VaccinationTypesModelMapper();
        private readonly VaccinationTypesOperationsInterface _vaccinationTypesOperations;
       public VaccinationTypeServicesClass(VaccinationTypesOperationsInterface vaccinationTypesOperations)
        {
            _vaccinationTypesOperations = vaccinationTypesOperations;
        }
        public void AddVaccinationTypes(VaccinationTypesDataModel vaccination)
        {
            // modelMapper.AddVaccinationType(vaccination);
            _vaccinationTypesOperations.AddVaccinationTypes(vaccination);

        }
        public void Edit(VaccinationTypesDataModel vaccination)
        {
            // modelMapper.Edit(vaccination);
            _vaccinationTypesOperations.Edit(vaccination);
        }
        public void Delete(int id    )
        {
            // modelMapper.Delete(id);
            _vaccinationTypesOperations.Delete(id);
        }
        public List<VaccinationTypesDataModel> list()
        {
            //return modelMapper.list();
            //VaccinationTypesModelMapper modelMapper = new VaccinationTypesModelMapper();
            //return modelMapper.list();
            return _vaccinationTypesOperations.list();


        }
        public VaccinationTypesDataModel GetById(int id)
        {
            //VaccinationTypesModelMapper modelMapper = new VaccinationTypesModelMapper();

            //return modelMapper.GetById(id);
            return _vaccinationTypesOperations.GetById(id);

        }

       
    }
}
