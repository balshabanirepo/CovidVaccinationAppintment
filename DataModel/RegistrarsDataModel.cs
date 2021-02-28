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
    }
}
