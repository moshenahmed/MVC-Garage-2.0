using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models.ViewModels
{
    public class ReceiptVM
    {

        public int Id { get; set; }
        [DisplayName("Vehicle Type")]
        public string Type { get; set; }
        [DisplayName("Vehicle Owner")]
        public string Owner { get; set; }
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }
        [DisplayName("Parking time")]
        public DateTime CheckIn { get; set; }
        [DisplayName("Checkout time")]
        public DateTime CheckOut { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Price Per Hour")]
        public int PricePerHour
        {
            get
            {
                return 100;
            }
        }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}")]
        [DisplayName("Total parking time")]
        public TimeSpan TotalTime
        {
            get
            {
                return (CheckOut - CheckIn);
            }
        }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Total")]
        public double Sum 
        {
            get
            {
                return TotalTime.TotalHours * PricePerHour;
            }
        }
    

        public ReceiptVM()
        {

        }

        public ReceiptVM(ParkedVehicle v)
        {
            Id = v.Id;
            this.Type = v.VehicleType.Name;
            RegNumber = v.RegNumber;
            CheckIn = v.CheckIn;
            Owner = v.Member.FullName;
         }

    }
}