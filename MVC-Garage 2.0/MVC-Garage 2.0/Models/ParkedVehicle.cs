using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models
{
    public class ParkedVehicle
    {
       

        public int Id { get; set; }
        [DisplayName("Vehicle Type")]
        public Type Type { get; set; }
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }
        [DisplayName("Vehicle Color")]
        public string Colour { get; set; }
        [DisplayName("Vehicle Brand")]
        public string Brand { get; set; }
        [DisplayName("Vehicle Model")]
        public string Model { get; set; }
        [DisplayName("Number Of Wheels")]
        public int NoOfWheels { get; set; }
        [DisplayName("Parking time")]
        public DateTime? CheckIn { get; set; }
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
 

}