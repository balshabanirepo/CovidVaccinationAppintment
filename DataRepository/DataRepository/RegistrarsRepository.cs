using System.ComponentModel.DataAnnotations;

namespace DataRepository
{
    public class RegistrarsRepository : Repository
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Telephone { get; set; }

        public bool Notified { get; set; }
    }
}