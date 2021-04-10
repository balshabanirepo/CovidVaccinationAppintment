using DataModel;
using DataRepository.DataRepositoryEntities;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.GateWay
{
   public class RegistrarsModelMapper
    {
        //RegistrarsOperationsInterface _registrarsOperationsInterface;
       
        public void AddRegistrar(RegistrarsDataModel model)
        {
            //RegistrarsRepository Registrars = new RegistrarsRepository();
            
            //Registrars.Name = model.Name;
            //Registrars.Telephone = model.Telephone;
            //_registrarsOperationsInterface.AddRegistrar(Registrars);

        }

        public void Edit(RegistrarsDataModel model)
        {
          
           
           // _registrarsOperationsInterface.Edit(model);
        }

        public void Notify(RegistrarsDataModel model)
        {

           // _registrarsOperationsInterface.Notify(model);
        }

        public void Delete(int id)
        {
           // _registrarsOperationsInterface.Delete(id);

        }

        public RegistrarsDataModel GetById(int id)
        {
            RegistrarsRepository Registrars  ;

            //Registrars= _registrarsOperationsInterface.GetById(id);
            //return new RegistrarsDataModel
            //{
            //    Id= Registrars.Id,
            //    Name=Registrars.Name,
            //    Telephone=Registrars.Telephone
            //};
            return null;
        }

        public List<RegistrarsDataModel> list()
        {


            //List<RegistrarsRepository> RegistrarsRepositories= _registrarsOperationsInterface.list();
            // return (from r in RegistrarsRepositories
            //         select new RegistrarsDataModel
            //         {
            //             Id = r.Id,
            //             Name = r.Name,
            //             Telephone=r.Telephone,
            //             Notified=r.Notified
            //         }).ToList();

            return null;

        }


    }
}
