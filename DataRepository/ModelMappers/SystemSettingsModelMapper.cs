using DataModel;
using DataRepository;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.ModelMappers.Interface;
namespace DataRepository.ModelMappers
{
   
    public class SystemSettingsModelMapper: ISystemSettingsModelMapper
    {
        RepositoryGateWay<SystemSettingsRepository> _repositoryGateWay;
        public SystemSettingsModelMapper()
        {
            _repositoryGateWay = new RepositoryGateWay<SystemSettingsRepository>();

        }

       

        public void AddSystemSettings(SystemSettingsDataModel model)
    {
        SystemSettingsRepository SystemSettings = new SystemSettingsRepository();

            SystemSettings.Token = model.Token;
            SystemSettings.NotificationType = (byte)model.NotificationType;

            _repositoryGateWay.Add(SystemSettings);

    }

    public void Edit(SystemSettingsDataModel model)
    {
            SystemSettingsRepository SystemSettings = new SystemSettingsRepository();
            SystemSettingsRepository SystemSettingsStoredInDb =(SystemSettingsRepository) _repositoryGateWay.GetById(g => g.Id == model.Id);
            SystemSettings.Token = model.Token;
            SystemSettings.NotificationType = (byte)model.NotificationType;
            SystemSettings.Id = model.Id;
            _repositoryGateWay.Edit(SystemSettingsStoredInDb, SystemSettings);
    }

    public void Delete(int id)
    {
       
        SystemSettingsRepository SystemSettings = (SystemSettingsRepository)_repositoryGateWay.GetById(c => c.Id == id);
            _repositoryGateWay.Delete(SystemSettings);

    }

    public SystemSettingsDataModel GetById(int id)
    {
       
        
            SystemSettingsRepository SystemSettings = (SystemSettingsRepository)_repositoryGateWay.GetById(c => c.Id == id);

            return new SystemSettingsDataModel { Token = SystemSettings.Token ,NotificationType=SystemSettings.NotificationType };


        }

    public List<SystemSettingsDataModel> list()
    {
            
           
            List<SystemSettingsRepository> SystemSettingsRepositories =_repositoryGateWay.List();
        return (from r in SystemSettingsRepositories
               select  new SystemSettingsDataModel
               {
                    Id = r.Id,
                    Token = r.Token,
                    NotificationType=r.NotificationType
               }).ToList();
          
    }
}
}
