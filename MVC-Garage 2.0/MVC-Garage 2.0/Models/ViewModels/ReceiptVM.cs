using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Garage_2._0.Models.ViewModels
{
    public class ReceiptVM
    {
        private int price = 100;
        private int sum;

        public int Id { get; set; }
        [DisplayName("Vehicle Type")]
        public string Type { get; set; }
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }
        [DisplayName("Parking time")]
        public DateTime? CheckIn { get; set; }
        [DisplayName("Checkout time")]
        public DateTime CheckOut { get; set; }
        public int Sum { get; set; }

        public ReceiptVM()
        {

        }

        public ReceiptVM(ParkedVehicle v)
        {
            Id = v.Id;
            Type = v.Type;
            RegNumber = v.RegNumber;
            CheckIn = v.CheckIn;
         }


    }
}