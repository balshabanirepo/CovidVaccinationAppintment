using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.ModelMappers.Interface;
using DataRepository.ModelMappers;
using DataRepository.GateWay;

namespace DataRepository.ModelMappers
{
    public class RegistrarsModelMapper : IRegistrarsModelMapper
    {
        RepositoryGateWay<RegistrarsRepository> _repositoryGateWay;
        public RegistrarsModelMapper()
        {
            //dataBaseGateWay = new RepositoryGateWay<RegistrarsRepository>();
            _repositoryGateWay = new RepositoryGateWay<RegistrarsRepository>();

        }

        public RegistrarsModelMapper(RepositoryGateWay<Repository> repositoryGateWay)
            
        {
            //_repositoryGateWay =(RepositoryGateWay<RegistrarsRepository>) repositoryGateWay;



       }
        public void AddRegistrar(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrars = new RegistrarsRepository();
            
            Registrars.Name = model.Name;
            Registrars.Telephone = model.Telephone;
            _repositoryGateWay.Add(Registrars);

        }

        public void Edit(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrars = new RegistrarsRepository();
            RegistrarsRepository RegistrarsStoredInModel = _repositoryGateWay.GetById(g => g.Id == model.Id);
            Registrars.Id = model.Id;
            Registrars.Name = model.Name;
            Registrars.Telephone = model.Telephone;
            Registrars.Notified = model.Notified;
            _repositoryGateWay.Edit(RegistrarsStoredInModel,Registrars);
        }

        public void Notify(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrars = new RegistrarsRepository();
            RegistrarsRepository RegistrarsStoredInModel = _repositoryGateWay.GetById(g => g.Id == model.Id);
            Registrars.Id = RegistrarsStoredInModel.Id;
            Registrars.Name = RegistrarsStoredInModel.Name;
            Registrars.Telephone = RegistrarsStoredInModel.Telephone;
            Registrars.Notified = model.Notified;
            _repositoryGateWay.Edit(RegistrarsStoredInModel, Registrars);
        }

        public void Delete(int id)
        {
            RegistrarsRepository Registrars;
            Registrars= _repositoryGateWay.GetById(c=>c.Id==id);
            _repositoryGateWay.Delete(Registrars);

        }

        public RegistrarsDataModel GetById(int id)
        {
            RegistrarsRepository Registrars  ;

            Registrars= _repositoryGateWay.GetById(c=>c.Id==id);
            return new RegistrarsDataModel
            {
                Id= Registrars.Id,
                Name=Registrars.Name,
                Telephone=Registrars.Telephone
            };

        }

        public List<RegistrarsDataModel> list()
        {
            

           List<RegistrarsRepository> RegistrarsRepositories= _repositoryGateWay.List();
            return (from r in RegistrarsRepositories
                    select new RegistrarsDataModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Telephone=r.Telephone,
                        Notified=r.Notified
                    }).ToList();

        }


    }
}
