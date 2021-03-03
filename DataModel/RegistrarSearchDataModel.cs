using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel
{
   public  class RegistrarSearchDataModel
    {
        [Required]
        public string SearchText { get; set; }


        public List<RegistrarsDataModel> Registrars { get; set; }
    }
}
