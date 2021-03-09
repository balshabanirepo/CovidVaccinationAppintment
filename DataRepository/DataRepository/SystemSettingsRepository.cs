using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository
{
   public class SystemSettingsRepository: Model
    {
        public int Id { get; set; }
        public string Token { get; set; }


        public byte NotificationType { get; set; }

    }
}
