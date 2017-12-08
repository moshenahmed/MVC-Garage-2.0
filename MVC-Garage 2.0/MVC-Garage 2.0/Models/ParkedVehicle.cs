using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage_2._0.Models
{
    public class ParkedVehicle
    {     

        public int Id { get; set; }
        [Required]
        [DisplayName("Vehicle Type")]
        public Type Type { get; set; }

        [Required]
        [Remote("IsVehicleExists", "ParkedVehicles", ErrorMessage = "Vehicle with the registration number already in use")]
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }

        [DisplayName("Vehicle Color")]
        public string Colour { get; set; }

        [DisplayName("Vehicle Brand")]
        public string Brand { get; set; }

        [DisplayName("Vehicle Model")]
        public string Model { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        [DisplayName("Number Of Wheels")]
        public int NoOfWheels { get; set; }

        [DisplayName("Parking time")]
        public DateTime CheckIn { get; set; }

        
    }
    public enum Type
    {
        
        Bus,
        Aeroplane,
        Boat,
        Bicycle,
        Motorbicycle,
        Car
    }
    public enum properties
    {
        RegistrationNumber,
        Color,
        Brand,
        Model,

    }

    


}