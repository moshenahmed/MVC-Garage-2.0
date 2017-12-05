namespace MVC_Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Garage_2._0.DataAccessLayer.RegisterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Garage_2._0.DataAccessLayer.RegisterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.ParkedVehicles.AddOrUpdate(x => x.RegNumber, new Models.ParkedVehicle()
            {
                RegNumber = "UAX456",
                Type = "Bus",
                Brand = "SLK",
                Colour = "Red",
                Model = "Sedan",
                NoOfWheels = 4,
                CheckIn = DateTime.Now


            },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFG597",
                Type = "Boat",
                Brand = "Trailor",
                Colour = "White",
                Model = "GTOD",
                NoOfWheels = 5,
                CheckIn = DateTime.Now
            }
            );
        }
    }
}
