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
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.
          context.VehicleTypes.AddOrUpdate(x => x.Name,
              new Models.VehicleType() { Name = "Bus" },
              new Models.VehicleType() { Name = "Aeroplane" },
              new Models.VehicleType() { Name = "Boat" },
              new Models.VehicleType() { Name = "Bicycle" },
              new Models.VehicleType() { Name = "Car" },
              new Models.VehicleType() { Name = "MotorBike" }
              );
            context.SaveChanges();

            context.Members.AddOrUpdate(x => x.Personnumber,
                new Models.Member() {
                    Personnumber = "198565249575",
                    FirstName ="Ahmed",
                    LastName = " kakeeto",
                    Address ="kabalagala 3 14521",
                    TelephoneNumber ="0797854264",
                    DateOfBirth =DateTime.Parse("1985/05/24") },
                
                new Models.Member()
                 {
                     Personnumber = "198665249575",
                     FirstName = "nakato",
                     LastName = " nabira",
                     Address = "nkumba 3 5990",
                     TelephoneNumber = "0754005225",
                     DateOfBirth = DateTime.Parse("1985/08/09")
                 },
                  new Models.Member()
                  {
                      Personnumber = "199065249575",
                      FirstName = "nakato",
                      LastName = " nabira",
                      Address = "nkumba 3 5990",
                      TelephoneNumber = "0754005225",
                      DateOfBirth = DateTime.Parse("1990/08/09")
                  },
                    new Models.Member()
                    {
                        Personnumber = "198665249575",
                        FirstName = "babirye",
                        LastName = " safiya",
                        Address = "nkumba 3 5990",
                        TelephoneNumber = "0772951318",
                        DateOfBirth = DateTime.Parse("1985/08/09")
                    }

                );


            context.SaveChanges();



            context.ParkedVehicles.AddOrUpdate(x => x.RegNumber,
                new Models.ParkedVehicle()
                {
                    RegNumber = "UAX456",
                    Type = context.VehicleTypes.ToList()[2].Id,
                    Brand = "SLK",
                    Colour = "Red",
                    Model = "Sedan",
                    NoOfWheels = 4,
                    CheckIn = DateTime.Now.AddDays(1),
                    MemberId=context.Members.ToList()[1].Id
                    


                },

            new Models.ParkedVehicle()
            {
                RegNumber = "SFG597",
                Type = context.VehicleTypes.ToList()[1].Id,
                Brand = "Trailor",
                Colour = "White",
                Model = "GTOD",
                NoOfWheels = 5,
                CheckIn = DateTime.Now.AddDays(2),
                MemberId = context.Members.ToList()[2].Id
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "ADF457",
                Type = context.VehicleTypes.ToList()[1].Id,
                Brand = "VikingLine",
                Colour = "Black",
                Model = "VK09",
                NoOfWheels = 10,
                CheckIn = DateTime.Now,
                MemberId = context.Members.ToList()[1].Id
            },

            new Models.ParkedVehicle()
            {
                RegNumber = "AGH123",
                Type = context.VehicleTypes.ToList()[3].Id,
                Brand = "AGH12",
                Colour = "Blue",
                Model = "HN09",
                NoOfWheels = 2,
                CheckIn = DateTime.Now,
                MemberId = context.Members.ToList()[0].Id
            }

            //new Models.ParkedVehicle()
            //{
            //    RegNumber = "AKL598",
            //    Type = Models.Type.Bus,
            //    Brand = "SL124",
            //    Colour = "Blue",
            //    Model = "KTOD",
            //    NoOfWheels = 8,
            //    CheckIn = DateTime.Now.AddDays(-1)
            //},

            //new Models.ParkedVehicle()
            //{
            //    RegNumber = "SFJ509",
            //    Type = Models.Type.Motorbicycle,
            //    Brand = "Honda",
            //    Colour = "Black",
            //    Model = "Davison",
            //    NoOfWheels = 3,
            //    CheckIn = DateTime.Now.AddDays(-2)
            //},

            //new Models.ParkedVehicle()
            //{
            //    RegNumber = "SFO917",
            //    Type = Models.Type.Aeroplane,
            //    Brand = "Trailor",
            //    Colour = "White",
            //    Model = "GTOD",
            //    NoOfWheels = 5,
            //    CheckIn = DateTime.Now
            //}

            );
            context.SaveChanges();
        }
    }
}
