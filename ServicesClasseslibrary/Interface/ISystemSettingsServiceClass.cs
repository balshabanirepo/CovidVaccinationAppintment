using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
    public interface ISystemSettingsServiceClass
    {
        public void Delete();

        public void SaveSystemSettings(SystemSettingsDataModel systemSettings);

        public SystemSettingsDataModel GetSystemSettings();

      
    }
}
