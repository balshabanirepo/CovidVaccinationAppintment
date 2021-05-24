using DataModel;
using DataRepository.GateWay;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses
{
    public class SystemSettingsOperationsClass : SystemSettingsOperationsInterface
    {

        ContextGateway dataBaseGateWay;
        public SystemSettingsOperationsClass()
        {
            dataBaseGateWay = new ContextGateway();
        }


        public void AddSystemSettings(SystemSettingsDataModel model)
        {
            SystemSettingsRepository SystemSettings = new SystemSettingsRepository();

            SystemSettings.Token = model.Token;
            if(model.NotificationType == null )
            {
                model.NotificationType = 1;
            }
            SystemSettings.NotificationType = (byte)model.NotificationType;

            dataBaseGateWay.SystemSettings.Add(SystemSettings);

        }

        public void Edit(SystemSettingsDataModel model)
        {
            SystemSettingsRepository SystemSettings = new SystemSettingsRepository();
            SystemSettingsRepository SystemSettingsStoredInDb = dataBaseGateWay.SystemSettings.GetById(g => g.Id == model.Id);
            SystemSettings.Token = model.Token;
            SystemSettings.NotificationType = (byte)model.NotificationType;
            SystemSettings.Id = model.Id;
            dataBaseGateWay.SystemSettings.Edit(SystemSettingsStoredInDb, SystemSettings);
        }

        public void Delete(int id)
        {

            SystemSettingsRepository SystemSettings = dataBaseGateWay.SystemSettings.GetById(c => c.Id == id);
            dataBaseGateWay.SystemSettings.Delete(SystemSettings);

        }

        public SystemSettingsDataModel GetById(int id)
        {


            SystemSettingsRepository SystemSettings = dataBaseGateWay.SystemSettings.GetById(c => c.Id == id);

            return new SystemSettingsDataModel { Token = SystemSettings.Token, NotificationType = SystemSettings.NotificationType };


        }

        public List<SystemSettingsDataModel> list()
        {


            List<SystemSettingsRepository> SystemSettingsRepositories = dataBaseGateWay.SystemSettings.List();
            return (from r in SystemSettingsRepositories
                    select new SystemSettingsDataModel
                    {
                        Id = r.Id,
                        Token = r.Token,
                        NotificationType = r.NotificationType
                    }).ToList();

        }

        public void SaveSystemSettings(SystemSettingsDataModel systemSettings)
        {
            List <SystemSettingsDataModel> SystemSettingsRepositories = this.list();
            if (SystemSettingsRepositories.Count>0)
            {
                systemSettings.Id = SystemSettingsRepositories[0].Id;
                Edit(systemSettings);

            }
            else
            {
                
                    AddSystemSettings(systemSettings);

                
            }
        }
    }
}
