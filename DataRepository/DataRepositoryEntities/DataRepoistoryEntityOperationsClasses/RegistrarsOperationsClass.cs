using DataModel;
using DataRepository.GateWay;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses
{
    public class RegistrarsOperationsClass : RegistrarsOperationsInterface
    {

        RepositoryGateWay<RegistrarsRepository> dataBaseGateWay;
        public RegistrarsOperationsClass()
        {
            dataBaseGateWay = new RepositoryGateWay<RegistrarsRepository>();

        }
        public void AddRegistrar(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrar;
            Registrar = new RegistrarsRepository();
            Registrar.Id = model.Id;
            Registrar.Name = model.Name;
            Registrar.Telephone = model.Telephone;
            Registrar.Notified = model.Notified;

            dataBaseGateWay.Add(Registrar);

        }

        public void Edit(RegistrarsDataModel model)
        {
            
            RegistrarsRepository RegistrarsStoredInModel = dataBaseGateWay.GetById(g => g.Id == model.Id),registrars;
            registrars = new RegistrarsRepository();
            registrars.Id = model.Id;
            registrars.Name = model.Name;
            registrars.Telephone = model.Telephone;
            registrars.Notified = model.Notified;
            dataBaseGateWay.Edit(RegistrarsStoredInModel, registrars);
        }

        public void Notify(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrars = new RegistrarsRepository();
            RegistrarsRepository RegistrarsStoredInModel = dataBaseGateWay.GetById(g => g.Id == model.Id);
            Registrars.Id = RegistrarsStoredInModel.Id;
            Registrars.Name = RegistrarsStoredInModel.Name;
            Registrars.Telephone = RegistrarsStoredInModel.Telephone;
            Registrars.Notified = model.Notified;
            dataBaseGateWay.Edit(RegistrarsStoredInModel, Registrars);
        }

        public void Delete(int id)
        {
            RegistrarsRepository Registrars;
            Registrars = dataBaseGateWay.GetById(c => c.Id == id);
            dataBaseGateWay.Delete(Registrars);

        }

        public RegistrarsDataModel GetById(int id)
        {
            RegistrarsRepository Registrars;

            Registrars = dataBaseGateWay.GetById(c => c.Id == id);
            return new RegistrarsDataModel
            {
                Id = Registrars.Id,
                Name = Registrars.Name,
                Telephone = Registrars.Telephone
            };
        

        }

        public List<RegistrarsDataModel> list()
        {


            List<RegistrarsRepository> RegistrarsRepositories = dataBaseGateWay.List();
            return (from r in RegistrarsRepositories
                    select new RegistrarsDataModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Telephone = r.Telephone,
                        Notified = r.Notified
                    }
                    ).ToList();

        }

        
    }
}
