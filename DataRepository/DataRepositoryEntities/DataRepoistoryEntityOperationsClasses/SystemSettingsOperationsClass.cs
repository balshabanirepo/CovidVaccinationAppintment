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

        RepositoryGateWay<SystemSettingsRepository> dataBaseGateWay;
        public SystemSettingsOperationsClass()
        {
            dataBaseGateWay = new RepositoryGateWay<SystemSettingsRepository>();
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
            SystemSettingsRepository SystemSettingsStoredInDb = dataBaseGateWay.GetById(g => g.Id == model.Id);
            SystemSettings.Token = model.Token;
            SystemSettings.NotificationType = (byte)model.NotificationType;
            SystemSettings.Id = model.Id;
            dataBaseGateWay.Edit(SystemSettingsStoredInDb, SystemSettings);
        }

        public void Delete(int id)
        {

            SystemSettingsRepository SystemSettings = dataBaseGateWay.GetById(c => c.Id == id);
            dataBaseGateWay.Delete(SystemSettings);

        }

        public SystemSettingsDataModel GetById(int id)
        {


            SystemSettingsRepository SystemSettings = dataBaseGateWay.GetById(c => c.Id == id);

            return new SystemSettingsDataModel { Token = SystemSettings.Token, NotificationType = SystemSettings.NotificationType };


        }

        public List<SystemSettingsDataModel> list()
        {


            List<SystemSettingsRepository> SystemSettingsRepositories = dataBaseGateWay.List();
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
            if(systemSettings.Id>0)
            {
                Edit(systemSettings);

            }
            else
            {
                
                    AddSystemSettings(systemSettings);

                
            }
        }
    }
}
