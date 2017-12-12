using MVC_Garage_2._0.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage_2._0.Models
{
    public class ParkedVehicle   //: IValidatableObject
    {     

        public int Id { get; set; }
        [Required]
        [DisplayName("Vehicle Type")]
        public Type Type { get; set; }

        [Required]
        [StringLength(50)]
        [CustomRemoteValidation("IsVehicleExist", "ParkedVehicles", AdditionalFields = "Id", ErrorMessage = "Vehicle registration number already exists")]
        [Index("Ix_RegNum", IsUnique = true)]
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }

        [DisplayName("Vehicle Color")]
        public string Colour { get; set; }

        [DisplayName("Vehicle Brand")]
        public string Brand { get; set; }

        [DisplayName("Vehicle Model")]
        public string Model { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        [DisplayName("Number Of Wheels")]
        public int NoOfWheels { get; set; }

        [Column(TypeName = "datetime2")]
        [DisplayName("Parking time")]
        public DateTime CheckIn { get; set; }

        

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    RegisterContext db = new RegisterContext();
        //    List<ValidationResult> validationResult = new List<ValidationResult>();
        //    var validateRegNum = db.ParkedVehicles.FirstOrDefault(x => x.RegNumber == RegNumber && x.Id != Id);
        //    if (validateRegNum != null)
        //    {
        //        ValidationResult errorMessage = new ValidationResult
        //        ("Vehicle registration number already exists.", new[] { "RegNumber" });
        //        //validationResult.Add(errorMessage);
        //        //return validationResult;
        //        yield return errorMessage;
        //    }
        //    else
        //    {
        //        //return validationResult;
        //        yield return ValidationResult.Success;
        //    }
        //}
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