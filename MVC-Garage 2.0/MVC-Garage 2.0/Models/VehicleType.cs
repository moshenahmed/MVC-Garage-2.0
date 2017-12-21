using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }

        public VehicleType()
        {

        }

        public VehicleType(string name)
        {
            Name = name;
        }

    }
}