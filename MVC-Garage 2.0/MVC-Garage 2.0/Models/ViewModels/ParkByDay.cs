﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models.ViewModels
{
    public class ParkByDay
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public IEnumerable<ParkedVehicle> VehicleList { get; set; }
    }
}