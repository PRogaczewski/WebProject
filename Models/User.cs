using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWebProject.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int rentId { get; set; }
        [Required(ErrorMessage = "Enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your lastname.")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Enter your phone number.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Required(ErrorMessage = "Enter your start date.")]
        [DisplayFormat(DataFormatString = "dd-MM-yy", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }
        [Required(ErrorMessage = "Enter your end date.")]
        [DisplayFormat(DataFormatString = "dd-MM-yy", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        public double TotalCost { get; set; }
    }
}
