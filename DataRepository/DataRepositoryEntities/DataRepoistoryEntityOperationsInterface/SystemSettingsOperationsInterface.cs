
using DataModel;
using DataRepository.DataRepositoryEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Interface.DataRepoistoryEntityOperationsInterface
{
    public interface SystemSettingsOperationsInterface
    {
        public void SaveSystemSettings(SystemSettingsDataModel systemSettings);




        public void Delete(int id);


        SystemSettingsDataModel GetById(int id);

        public List<SystemSettingsDataModel> list();
    }
}
