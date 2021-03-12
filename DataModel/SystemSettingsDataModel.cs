using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel
{
   public class SystemSettingsDataModel 
    {
        public int Id { get; set; }

        public string Token { get; set; }

        [Required]
        public byte? NotificationType { get; set; }

    }
}
