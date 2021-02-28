using System.ComponentModel.DataAnnotations;

namespace DataRepository
{
     class RegistrarsRepository: Model
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Telephone { get; set; }
    }
}