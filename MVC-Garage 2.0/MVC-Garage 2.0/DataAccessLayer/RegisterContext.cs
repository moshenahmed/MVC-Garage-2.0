using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Garage_2._0.DataAccessLayer
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(): base ("Garage2.5")
        {

        }
        public DbSet<Models.ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }

    }
}