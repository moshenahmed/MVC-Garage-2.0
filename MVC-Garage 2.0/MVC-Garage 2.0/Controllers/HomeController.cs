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
        public ActionResult Index(string Searchtext=null)
        {
            var model = new List<ParkedVehicle>();
      
            if (!String.IsNullOrEmpty(Searchtext))
            {
                model = db.ParkedVehicles.Where(s => s.RegNumber.Contains(Searchtext)).ToList();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("Search", model);
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