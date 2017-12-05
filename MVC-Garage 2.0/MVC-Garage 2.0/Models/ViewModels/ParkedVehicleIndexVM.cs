using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models.ViewModels
{
    public class ParkedVehicleIndexVM
    {
        public int Id { get; set; }
        [DisplayName("Vehicle Type")]
        public Type Type { get; set; }
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }
        [DisplayName("Vehicle Color")]
        public string Colour { get; set; }
        [DisplayName("Parking time")]
        public DateTime? CheckIn { get; set; }

        public ParkedVehicleIndexVM()
        {

        }

        public ParkedVehicleIndexVM(ParkedVehicle v)
        {
            Id = v.Id;
            Type =v.Type;
            RegNumber = v.RegNumber;
            Colour = v.Colour;
            CheckIn = v.CheckIn;
        }
    }
}