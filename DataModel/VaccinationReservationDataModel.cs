using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel
{
    public class VaccinationReservationDataModel
    {
        public int Id { get; set; }
      [Required]
        public int? RegistrarId { get; set; }
        [Required]
        public int? VaccinationTypeId { get; set; }
        [Required]
        public DateTime ReservationDateTime { get; set; }

        public bool Taken { get; set; }

        public virtual RegistrarsDataModel Registrar { get; set; }
        public virtual VaccinationTypesDataModel VaccinationType { get; set; }




    }
}
