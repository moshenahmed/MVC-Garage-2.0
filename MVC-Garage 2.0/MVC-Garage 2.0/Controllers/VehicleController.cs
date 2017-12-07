using MVC_Garage_2._0.DataAccessLayer;
using MVC_Garage_2._0.Models;
using MVC_Garage_2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage_2._0.Controllers
{
    public class VehicleController : Controller
    {
        private RegisterContext db = new RegisterContext();
        // GET: Vehicle
        public ActionResult Index(string regNum = "")
        {
            
            ParkedVehicle vehicle = new ParkedVehicle();
            if (regNum != null)
            {
                vehicle = db.ParkedVehicles.FirstOrDefault(v => v.RegNumber == regNum);
            }
           

            return View(vehicle);
        }


        public ActionResult AutoComplete(string term)
        {
            var model = db.ParkedVehicles.Where(v => v.RegNumber.StartsWith(term))
                .Take(10)
                .Select(v => new { label = v.RegNumber });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

       
    }
}