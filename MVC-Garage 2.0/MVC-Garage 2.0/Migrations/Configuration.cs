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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC_Garage_2._0.DataAccessLayer.RegisterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.ParkedVehicles.AddOrUpdate(x => x.RegNumber, new Models.ParkedVehicle()
            {
                RegNumber = "UAX456",
                Type = Models.Type.Bus,
                Brand = "SLK",
                Colour = "Red",
                Model = "Sedan",
                NoOfWheels = 4,
                CheckIn = DateTime.Now.AddDays(-1)


            },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFG597",
                Type = Models.Type.Aeroplane,
                Brand = "Trailor",
                Colour = "White",
                Model = "GTOD",
                NoOfWheels = 5,
                CheckIn = DateTime.Now.AddDays(-2)
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "ADF457",
                Type = Models.Type.Boat,
                Brand = "VikingLine",
                Colour = "Black",
                Model = "VK09",
                NoOfWheels = 10,
                CheckIn = DateTime.Now
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "AGH123",
                Type = Models.Type.Bicycle,
                Brand = "AGH12",
                Colour = "Blue",
                Model = "HN09",
                NoOfWheels = 2,
                CheckIn = DateTime.Now
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "AKL598",
                Type = Models.Type.Bus,
                Brand = "SL124",
                Colour = "Blue",
                Model = "KTOD",
                NoOfWheels = 8,
                CheckIn = DateTime.Now.AddDays(-1)
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFJ509",
                Type = Models.Type.Motorbicycle,
                Brand = "Honda",
                Colour = "Black",
                Model = "Davison",
                NoOfWheels = 3,
                CheckIn = DateTime.Now.AddDays(-2)
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFO917",
                Type = Models.Type.Aeroplane,
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
