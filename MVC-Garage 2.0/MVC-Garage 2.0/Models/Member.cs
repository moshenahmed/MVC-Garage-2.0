using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVC_Garage_2._0.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "That Personnumber is to long")]
        [MinLength(10, ErrorMessage = "That Personnumber is to short")]

        public string Personnumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        [Required]
       // [MaxLength(8, ErrorMessage = "That Date of birth is to long")]
       // [MinLength(0, ErrorMessage = "That Date of birth is to short")]
        [DataType(DataType.Date)]
       
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}