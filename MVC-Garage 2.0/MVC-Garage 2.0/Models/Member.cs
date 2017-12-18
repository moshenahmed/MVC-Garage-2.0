using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Personnumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}