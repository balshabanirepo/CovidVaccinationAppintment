using DataModel;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using DataRepository.ModelMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
    public class SystemSettingsServiceClass : ISystemSettingsServiceClass
    {
        //private SystemSettingsModelMapper settingsModelMapper;
        private readonly SystemSettingsOperationsInterface _systemSettingsOperations;
       


        public SystemSettingsServiceClass(SystemSettingsOperationsInterface systemSettingsOperations)
        {
           // settingsModelMapper = new SystemSettingsModelMapper();

                _systemSettingsOperations=systemSettingsOperations;
        }
        public void SaveSystemSettings(SystemSettingsDataModel systemSettings)
        {

            _systemSettingsOperations.SaveSystemSettings(systemSettings);
        }
        ////private void AddSystemSettings(SystemSettingsDataModel systemSettings)
        ////{

        ////    _systemSettingsOperations.AddSystemSettings(systemSettings);

        ////}
        ////private void EditSystemSettings(SystemSettingsDataModel systemSettings)
        ////{

        ////    _systemSettingsOperations.Edit(systemSettings);

        ////}
        public SystemSettingsDataModel GetSystemSettings()
        {
            //SystemSettingsModelMapper settingsModelMapper= new SystemSettingsModelMapper ();

            //List<SystemSettingsDataModel> systemSettingList = settingsModelMapper.list();
            //if (systemSettingList.Count > 0)
            //{
            //    return systemSettingList[0];


            //}
            List<SystemSettingsDataModel> systemSettingList = _systemSettingsOperations.list();
            if (systemSettingList.Count > 0)
            {
                return systemSettingList[0];


            }
            return new SystemSettingsDataModel { Id = 0 };

        }
        public void Delete()
        {

            List<SystemSettingsDataModel> systemSettingList = _systemSettingsOperations.list();
            if (systemSettingList.Count > 0)
            {
                _systemSettingsOperations.Delete(systemSettingList[0].Id);


            }
            


            

          

        }

       
    }
}
