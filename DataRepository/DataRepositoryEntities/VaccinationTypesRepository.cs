using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.DataRepositoryEntities
{
   public  class VaccinationTypesRepository:IRepository
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }

        public virtual IEnumerable<VaccinationReservationRepository> VaccinationReservations { get; set; }


    }
}