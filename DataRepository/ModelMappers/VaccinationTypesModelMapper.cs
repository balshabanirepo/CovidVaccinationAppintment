using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.ModelMappers.Interface;
using DataRepository.GateWay;

namespace DataRepository.ModelMappers
{
   public class VaccinationTypesModelMapper: IVaccinationTypesModelMapper
    {

        RepositoryGateWay<VaccinationTypesRepository>  _repositoryGateWay;
        public VaccinationTypesModelMapper()
        {
            //dataBaseGateWay = new RepositoryGateWay<RegistrarsRepository>();
            _repositoryGateWay = new RepositoryGateWay<VaccinationTypesRepository>();

        }

        public VaccinationTypesModelMapper(RepositoryGateWay<Repository> repositoryGateWay)

        {
           



        }
        public void AddVaccinationType(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            
            vaccinationTypes.Name = model.Name;
            _repositoryGateWay.Add(vaccinationTypes);

        }

        public void Edit(VaccinationTypesDataModel model)
        {
            VaccinationTypesRepository vaccinationTypes = new VaccinationTypesRepository();
            VaccinationTypesRepository vaccinationTypesStoredInDb = (VaccinationTypesRepository)_repositoryGateWay.GetById(g => g.Id == model.Id);
            vaccinationTypes.Id = model.Id;
            vaccinationTypes.Name = model.Name;
            _repositoryGateWay.Edit(vaccinationTypesStoredInDb,vaccinationTypes);
        }

        public void Delete(int id)
        {
            VaccinationTypesRepository vaccinationTypes;
            vaccinationTypes= (VaccinationTypesRepository)_repositoryGateWay.GetById(c=>c.Id==id);
            _repositoryGateWay.Delete(vaccinationTypes);

        }

        public VaccinationTypesDataModel GetById(int id)
        {
            VaccinationTypesRepository vaccinationTypes  ;

            vaccinationTypes= (VaccinationTypesRepository)_repositoryGateWay.GetById(c=>c.Id==id);
            return new VaccinationTypesDataModel
            {
                Id= vaccinationTypes.Id,
                Name=vaccinationTypes.Name
            };

        }

        public List<VaccinationTypesDataModel> list()
        {
            

           List<VaccinationTypesRepository> vaccinationTypesRepositories= _repositoryGateWay.List();
            return (from r in  vaccinationTypesRepositories
                    select new VaccinationTypesDataModel
                    {
                        Id = r.Id,
                        Name = r.Name
                    }).ToList();

        }


    }
}
