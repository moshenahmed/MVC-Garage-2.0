using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Personnumber { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [DisplayName("Telephone Number")]
        public string TelephoneNumber { get; set; }

        [DisplayName("Date Of Birth")]
        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}