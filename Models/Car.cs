using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWebProject.Models
{
    [Table("cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public double Price { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
