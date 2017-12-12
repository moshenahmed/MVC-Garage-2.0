using MVC_Garage_2._0.DataAccessLayer;
using MVC_Garage_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage_2._0.Controllers
{
    public class HomeController : Controller
    {
        private RegisterContext db = new RegisterContext();
        public ActionResult Index(string Searchtext=null, string Category = "", string sortOrder = "")
        {
            var model = new List<ParkedVehicle>();
      
            if (!String.IsNullOrEmpty(Searchtext))
            {
                if (Category == "RegNo")
                {
                    model = db.ParkedVehicles.Where(s => s.RegNumber.Contains(Searchtext)).ToList();
                }

                else if (Category == "Color")
                {
                    model = db.ParkedVehicles.Where(s => s.Colour.Contains(Searchtext)).ToList();
                }
                else if (Category == "NoOfWheels")
                {
                    var NoOfWheels = int.Parse(Searchtext);
                    model = db.ParkedVehicles.Where(s => s.NoOfWheels == NoOfWheels).ToList();
                }
                else if (Category == "Model")
                {
                    model = db.ParkedVehicles.Where(s => s.Model.Contains(Searchtext)).ToList();
                }
                
                else if (Category == "Type")
                {
                    
                  
                        Models.Type typeValue = (Models.Type)Enum.Parse(typeof(Models.Type), Searchtext, true);
                        if (Enum.IsDefined(typeof(Models.Type), typeValue)){
                            model = db.ParkedVehicles.Where(s => s.Type == typeValue).ToList();
                        }
                }
                else if (Category == "Brand")
                {
                    model = db.ParkedVehicles.Where(s => s.Brand.Equals(Searchtext)).ToList();
                }
                
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("Search", model);
            }
            //ViewBag.RegnoSort = String.IsNullOrEmpty(sortOrder) ? "RegNo" : "";
            ViewBag.RegSort = sortOrder == "RegNo" ? "RegNo" : "RegNo";


            switch (sortOrder)
            {
                case "RegNo":
                    model = model.OrderByDescending(s => s.RegNumber).ToList();
                  
                    break;
                case "Color":
                    model = model.OrderByDescending(s => s.Colour).ToList();
                    break;
                case "NoOfWheels":
                    model = model.OrderByDescending(s => s.NoOfWheels).ToList();
                    break;
                default:
                    model = model.OrderByDescending(s => s.Brand).ToList();
                    break;
            }

            return View(model);
        }



        //public ActionResult Search(string Searchtext)
        //{

            


        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}