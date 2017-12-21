using MVC_Garage_2._0.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models.ViewModels
{
    public class ParkedVehicleDetail : IValidatableObject
    {
        public int Id { get; set; }
        public string Type { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
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

        [Column(TypeName = "datetime2")]
        [DisplayName("Parking time")]
        public DateTime CheckIn { get; set; }

        public ParkedVehicleDetail()
        {

        }

        public ParkedVehicleDetail(ParkedVehicle v)
        {
            Id = v.Id;
            RegNumber = v.RegNumber;
            Colour = v.Colour;
            Model = v.Model;
            Brand = v.Brand;
            NoOfWheels = v.NoOfWheels;
            CheckIn = v.CheckIn;
            Type = v.VehicleType.Name;
            Owner = v.Member.FullName;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            RegisterContext db = new RegisterContext();
            List<ValidationResult> validationResult = new List<ValidationResult>();
            var members = db.Members.ToList();
            var validateUser = members.FirstOrDefault(x => x.FullName == Owner);
            if (validateUser == null)
            {
                ValidationResult errorMessage = new ValidationResult
                ("Vehicle owner does not exists.", new[] { "Owner" });
                //validationResult.Add(errorMessage);
                //return validationResult;
                yield return errorMessage;
            }
            else
            {
                //return validationResult;
                yield return ValidationResult.Success;
            }
        }
    }


}