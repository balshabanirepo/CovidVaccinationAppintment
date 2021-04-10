using DataModel;
using DataRepository.DataRepositoryEntities;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.GateWay
{
   public class VaccinationTypesModelMapper
    {
         
          VaccinationTypesOperationsInterface _vaccinationTypesOperationsInterface;
        public VaccinationTypesModelMapper()
        {
            
        }


      

        public VaccinationTypesDataModel GetById(int id)
        {


            //VaccinationTypesRepository VaccinationTypes = _vaccinationTypesOperationsInterface.GetById(id);

            //return new VaccinationTypesDataModel { Id = VaccinationTypes.Id, Name = VaccinationTypes.Name };
            return null;


        }

        public List<VaccinationTypesDataModel> list()
        {


            //List<VaccinationTypesRepository> VaccinationTypesRepositories = _vaccinationTypesOperationsInterface.list();
            //return (from r in VaccinationTypesRepositories
            //        select new VaccinationTypesDataModel
            //        {
            //            Id = r.Id,
            //            Name = r.Name,

            //        }).ToList();

            return null;


        }


    }
}
