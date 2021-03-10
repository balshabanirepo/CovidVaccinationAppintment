using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class RegistrarsDataModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Range(1,1,ErrorMessage ="Please enter a valid Phone number")]
        public byte ValidTelephone { get; set; }

        public bool GivenAppointment { get; set; }
    }
}
