using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.GateWay
{
   public class RegistrarsModelMapper
    {
         RepositoryGateWay<RegistrarsRepository> dataBaseGateWay;
        public RegistrarsModelMapper()
             {
                dataBaseGateWay = new RepositoryGateWay<RegistrarsRepository>();

             }
        public void AddRegistrar(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrars = new RegistrarsRepository();
            
            Registrars.Name = model.Name;
            Registrars.Telephone = model.Telephone;
            dataBaseGateWay.Add(Registrars);

        }

        public void Edit(RegistrarsDataModel model)
        {
            RegistrarsRepository Registrars = new RegistrarsRepository();
            RegistrarsRepository RegistrarsStoredInModel = dataBaseGateWay.GetById(g => g.Id == model.Id);
            Registrars.Id = model.Id;
            Registrars.Name = model.Name;
            Registrars.Telephone = model.Telephone;
            Registrars.Notified = model.Notified;
            dataBaseGateWay.Edit(RegistrarsStoredInModel,Registrars);
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
            Registrars= dataBaseGateWay.GetById(c=>c.Id==id);
            dataBaseGateWay.Delete(Registrars);

        }

        public RegistrarsDataModel GetById(int id)
        {
            RegistrarsRepository Registrars  ;

            Registrars= dataBaseGateWay.GetById(c=>c.Id==id);
            return new RegistrarsDataModel
            {
                Id= Registrars.Id,
                Name=Registrars.Name,
                Telephone=Registrars.Telephone
            };

        }

        public List<RegistrarsDataModel> list()
        {
            

           List<RegistrarsRepository> RegistrarsRepositories= dataBaseGateWay.List();
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
