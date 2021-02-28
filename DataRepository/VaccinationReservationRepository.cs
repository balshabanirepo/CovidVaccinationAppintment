using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository
{
     class VaccinationReservationRepository: Model
    {
        public int Id { get; set; }
        [ForeignKey("Registrar")]
        public int RegistrarId { get; set; }
        [ForeignKey("VaccinationType")]
        public int  VaccinationTypeId { get; set; }

        public DateTime ReservationDateTime { get; set; }

        public bool  Taken { get; set; }

        public virtual RegistrarsRepository Registrar { get; set; }
        public virtual VaccinationTypesRepository VaccinationType { get; set; }

      


    }
}