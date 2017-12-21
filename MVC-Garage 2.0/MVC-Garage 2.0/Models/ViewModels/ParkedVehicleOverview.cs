using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models.ViewModels
{
    public class ParkedVehicleOverview
    {
        public int Id { get; set; }
        [DisplayName("Vehicle Type")]
        public string Type { get; set; }
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }
        [DisplayName("Vehicle Owner")]
        public string Owner { get; set; }
        [DisplayName("Parking time")]
        public DateTime CheckIn { get; set; }

        public ParkedVehicleOverview()
        {

        }

        public ParkedVehicleOverview(ParkedVehicle v)
        {
            Id = v.Id;
            RegNumber = v.RegNumber;
            CheckIn = v.CheckIn;
        }
    }
}