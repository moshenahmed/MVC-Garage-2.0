﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MVC_Garage_2._0.Models
{
    public class ParkedVehicle
    {
       

        public int Id { get; set; }
        public Type Type { get; set; }
        public string RegNumber { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NoOfWheels { get; set; }
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