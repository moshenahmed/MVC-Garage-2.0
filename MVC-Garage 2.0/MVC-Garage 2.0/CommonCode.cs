using MVC_Garage_2._0.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage_2._0
{
    /// <summary>
    /// https://www.codeproject.com/Articles/1130342/Best-ways-of-implementing-Uniqueness-or-Unique-Key
    /// </summary>
    public class CustomRemoteValidation : RemoteAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            RegisterContext db = new RegisterContext();

            //Take the additional field property name and value
            PropertyInfo additionalPropertyName =
            validationContext.ObjectInstance.GetType().GetProperty(AdditionalFields);
            object additionalPropertyValue =
            additionalPropertyName.GetValue(validationContext.ObjectInstance, null);

            bool validateRegNumber = db.ParkedVehicles.Any(x => x.RegNumber == (string)value && x.Id != (int)additionalPropertyValue);
            if (validateRegNumber == true)
            {
                return new ValidationResult
                ("The vehicle registration already exist", new string[] { "RegNumber" });
            }
            return ValidationResult.Success;
        }

        public CustomRemoteValidation(string routeName)
            : base(routeName)
        {
        }

        public CustomRemoteValidation(string action, string controller)
            : base(action, controller)
        {
        }

        public CustomRemoteValidation(string action, string controller,
            string areaName) : base(action, controller, areaName)
        {
        }
    }
}