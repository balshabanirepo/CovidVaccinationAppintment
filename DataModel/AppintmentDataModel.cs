using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Xpo;

namespace DataModel
{

    public class AppintmentDataModel
    { 
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string RegistrarIds { get; set; }
    }

}