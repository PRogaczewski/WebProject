using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWebProject.Models
{
    [Table("cities")]
    public class City
    {
        [Key]
        [Required(ErrorMessage = "Select city")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
