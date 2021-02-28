using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel
{
    public class VaccinationTypesDataModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<VaccinationReservationDataModel> VaccinationReservations { get; set; }
    }
}
