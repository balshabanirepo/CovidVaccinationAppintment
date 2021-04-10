using DataModel;
using DataRepository;
using DataRepository.DataRepositoryEntities;
using DataRepository.GateWay;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.ModelMappers
{
   
    public class SystemSettingsModelMapper
    {
       
        public SystemSettingsModelMapper() { }
    

   
    public SystemSettingsDataModel GetById(int id)
    {


            //SystemSettingsRepository SystemSettings = _SystemSettingsOperations.GetById(id);

            //return new SystemSettingsDataModel { Token = SystemSettings.Token ,NotificationType=SystemSettings.NotificationType };

            return null;
        }

    public List<SystemSettingsDataModel> list()
    {


            //List<SystemSettingsRepository> SystemSettingsRepositories = _SystemSettingsOperations.list();
            //return (from r in SystemSettingsRepositories
            //       select new SystemSettingsDataModel
            //       {
            //            Id = r.Id,
            //            Token = r.Token,
            //            NotificationType=r.NotificationType
            //       }).ToList();
            return null;

        }
}
}
