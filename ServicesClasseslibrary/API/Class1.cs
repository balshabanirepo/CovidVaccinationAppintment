using DataModel;
using DataRepository.GateWay;
using DataRepository.ModelMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ServicesClasseslibrary.API
{
    public class SystemSettingsServiceClass: ISystemSettingsServiceClass
    {
        private SystemSettingsModelMapper modelMapper = new SystemSettingsModelMapper();
        public SystemSettingsDataModel GetSystemsettingsdatamodel()
        {

            return modelMapper.list().FirstOrDefault();
        }
    }
}
