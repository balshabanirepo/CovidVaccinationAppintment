using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataRepository
{
   public  class VaccinationTypesRepository: Repository
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }

        public virtual IEnumerable<VaccinationReservationRepository> VaccinationReservations { get; set; }


    }
}