using DataModel;
using DataRepository.ModelMappers;
using DataRepository.ModelMappers.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
    public class SystemSettingsServiceClass : ISystemSettingsServiceClass
    {
        private ISystemSettingsModelMapper settingsModelMapper;


        public SystemSettingsServiceClass()
        {
           // settingsModelMapper = new SystemSettingsModelMapper();

        }
        public SystemSettingsServiceClass(ISystemSettingsModelMapper iSystemSettingsModelMapper)
        {
            settingsModelMapper= iSystemSettingsModelMapper;

        }
        public void SaveSystemSettings(SystemSettingsDataModel systemSettings)
        {
           
            if (systemSettings.Id>0)
            {
               
                EditSystemSettings(systemSettings);
            }
            else
            {
                AddSystemSettings(systemSettings);
            }
        }
        private void AddSystemSettings(SystemSettingsDataModel systemSettings)
        {

            settingsModelMapper.AddSystemSettings(systemSettings);

        }
        private void EditSystemSettings(SystemSettingsDataModel systemSettings)
        {

            settingsModelMapper.Edit(systemSettings);

        }
        public SystemSettingsDataModel GetSystemSettings()
        {
            List<SystemSettingsDataModel> systemSettingList = settingsModelMapper.list();
            if (systemSettingList.Count > 0)
            {
                return systemSettingList[0];


            }

            return new SystemSettingsDataModel { Id = 0 };

        }
        public void Delete()
        {
            List<SystemSettingsDataModel> systemSettingList = settingsModelMapper.list();
            if (systemSettingList.Count > 0)
            {
                settingsModelMapper.Delete(systemSettingList[0].Id);


            }

          

        }
    }
}
