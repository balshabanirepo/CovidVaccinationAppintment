using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.ModelMappers.Interface
{
    public interface ISystemSettingsModelMapper
    {
        void AddSystemSettings(SystemSettingsDataModel model);
        void Edit(SystemSettingsDataModel model);

        void Delete(int id);
        SystemSettingsDataModel GetById(int id);

        List<SystemSettingsDataModel> list();
    }
}
