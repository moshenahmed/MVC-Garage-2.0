namespace MVC_Garage_2._0.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

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

            context.VehicleTypes.AddOrUpdate(x => x.Name,
                new VehicleType() { Name = "Bus" },
                new VehicleType() { Name = "Boat" },
                new VehicleType() { Name = "Aeroplane" },
                new VehicleType() { Name = "Car" },
                new VehicleType() { Name = "Bicycle" },
                new VehicleType() { Name = "Motorbicycle" }
                );
            context.SaveChanges();
            context.Members.AddOrUpdate(x => x.Personnumber,
                new Member()
                {
                    Personnumber = "197021221234",
                    FirstName = "Billy",
                    LastName = "Ted",
                    DateOfBirth = DateTime.Now.AddYears(-5),
                    Address = "Blabla Street 0",
                    TelephoneNumber = "555-55670"
                },
                new Member()
                {
                    Personnumber = "198610090034",
                    FirstName = "Steve",
                    LastName = "Johansson",
                    DateOfBirth = DateTime.Now.AddYears(-50),
                    Address = "Blabla Street 0",
                    TelephoneNumber = "555-67905"
                },
                new Member()
                {
                    Personnumber = "197509121136",
                    FirstName = "Sara",
                    LastName = "Wilson",
                    DateOfBirth = DateTime.Now.AddYears(-35),
                    Address = "Blabla Street 0",
                    TelephoneNumber = "555-555555"
                }

                );
            context.SaveChanges();


            var genMem = context.Members.Count();
            var genType = context.VehicleTypes.Count();
            Random r = new Random();

            context.ParkedVehicles.AddOrUpdate(x => x.RegNumber,
                new Models.ParkedVehicle()
                {
                    RegNumber = "UAX456",
                    TypeId = r.Next(1, genType),
                    MemberId = r.Next(1, genMem),
                    Brand = "SLK",
                    Colour = "Red",
                    Model = "Sedan",
                    NoOfWheels = 4,
                    CheckIn = DateTime.Now.AddDays(-1)


                },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFG597",
                TypeId = r.Next(1, genType),
                MemberId = r.Next(1, genMem),
                Brand = "Trailor",
                Colour = "White",
                Model = "GTOD",
                NoOfWheels = 5,
                CheckIn = DateTime.Now.AddDays(-2)
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "ADF457",
                TypeId = r.Next(1, genType),
                MemberId = r.Next(1, genMem),
                Brand = "VikingLine",
                Colour = "Black",
                Model = "VK09",
                NoOfWheels = 10,
                CheckIn = DateTime.Now
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "AGH123",
                TypeId = r.Next(1, genType),
                MemberId = r.Next(1, genMem),
                Brand = "AGH12",
                Colour = "Blue",
                Model = "HN09",
                NoOfWheels = 2,
                CheckIn = DateTime.Now
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "AKL598",
                TypeId = r.Next(1, genType),
                MemberId = r.Next(1, genMem),
                Brand = "SL124",
                Colour = "Blue",
                Model = "KTOD",
                NoOfWheels = 8,
                CheckIn = DateTime.Now.AddDays(-1)
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFJ509",
                TypeId = r.Next(1, genType),
                MemberId = r.Next(1, genMem),
                Brand = "Honda",
                Colour = "Black",
                Model = "Davison",
                NoOfWheels = 3,
                CheckIn = DateTime.Now.AddDays(-2)
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFO917",
                TypeId = r.Next(1, genType),
                MemberId = r.Next(1, genMem),
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
