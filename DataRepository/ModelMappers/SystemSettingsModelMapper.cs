using DataModel;
using DataRepository;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository.ModelMappers
{
   
    public class SystemSettingsModelMapper
    {
        DataBaseGateWay<SystemSettingsRepository> dataBaseGateWay;
        public SystemSettingsModelMapper()
        {
            dataBaseGateWay = new DataBaseGateWay<SystemSettingsRepository>();
        }
    

    public void AddSystemSettings(SystemSettingsDataModel model)
    {
        SystemSettingsRepository SystemSettings = new SystemSettingsRepository();

            SystemSettings.Token = model.Token;
            SystemSettings.NotificationType = (byte)model.NotificationType;

            dataBaseGateWay.Add(SystemSettings);

    }

    public void Edit(SystemSettingsDataModel model)
    {
            SystemSettingsRepository SystemSettings = new SystemSettingsRepository();
            SystemSettings.Token = model.Token;
            SystemSettings.NotificationType = (byte)model.NotificationType;
            SystemSettings.Id = model.Id;
            dataBaseGateWay.Edit(SystemSettings);
    }

    public void Delete(int id)
    {
       
        SystemSettingsRepository SystemSettings = dataBaseGateWay.GetById(c => c.Id == id);
        dataBaseGateWay.Delete(SystemSettings);

    }

    public SystemSettingsDataModel GetById(int id)
    {
       
        
            SystemSettingsRepository SystemSettings = dataBaseGateWay.GetById(c => c.Id == id);

            return new SystemSettingsDataModel { Token = SystemSettings.Token ,NotificationType=SystemSettings.NotificationType };


        }

    public List<SystemSettingsDataModel> list()
    {


        List<SystemSettingsRepository> SystemSettingsRepositories = dataBaseGateWay.List();
        return (from r in SystemSettingsRepositories
               select new SystemSettingsDataModel
               {
                    Id = r.Id,
                    Token = r.Token,
                    NotificationType=r.NotificationType
               }).ToList();
          
    }
}
}
