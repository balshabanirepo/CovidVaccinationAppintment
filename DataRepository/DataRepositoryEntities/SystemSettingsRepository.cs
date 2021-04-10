using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataRepositoryEntities
{
   public class SystemSettingsRepository:IRepository
    {
        public int Id { get; set; }
        public string Token { get; set; }


        public byte NotificationType { get; set; }

    }
}
