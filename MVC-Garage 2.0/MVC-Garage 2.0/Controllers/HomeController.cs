using MVC_Garage_2._0.DataAccessLayer;
using MVC_Garage_2._0.Models;
using MVC_Garage_2._0.Models.ViewModels;
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
        public ActionResult Index(string Searchtext, string Category, string sortOrder)
        {

            if (Session["CurrentSearch"] != null && Searchtext == null)
            {
                Searchtext = Session["CurrentSearch"].ToString();
            }
            else
            {
                Session["CurrentSearch"] = Searchtext;
            }


            if (Session["CurrentCategory"] != null && Category == null)
            {
                Category = Session["CurrentCategory"].ToString();
            }
            else
            {
                Session["CurrentCategory"] = Category;
            }






            var model = new List<ParkedVehicleDetail>();
            foreach (var v in db.ParkedVehicles)
            {
                var vehicleDetail = new ParkedVehicleDetail(v);
                model.Add(vehicleDetail);
            }

            if (!String.IsNullOrEmpty(Searchtext))
            {
                if (Category == "RegNo")
                {
                    model = model.Where(s => s.RegNumber.Contains(Searchtext)).ToList();
                }

                else if (Category == "Color")
                {
                    model = model.Where(s => s.Colour.Contains(Searchtext)).ToList();
                }
                else if (Category == "NoOfWheels")
                {
                    var NoOfWheels = int.Parse(Searchtext);
                    model = model.Where(s => s.NoOfWheels == NoOfWheels).ToList();
                }
                else if (Category == "Model")
                {
                    model = model.Where(s => s.Model.Contains(Searchtext)).ToList();
                }

                else if (Category == "Type")
                {
                    model = model.Where(s => s.Type == Searchtext).ToList();
                }
                else if (Category == "Brand")
                {
                    model = model.Where(s => s.Brand.Equals(Searchtext)).ToList();
                }

            }



            ViewBag.RegNoSortParm = String.IsNullOrEmpty(sortOrder) ? "reg_desc" : "";
            ViewBag.ColorSortParm = sortOrder == "Color" ? "color_desc" : "Color";
            ViewBag.WheelsSortParm = sortOrder == "NoOfWheels" ? "wheels_desc" : "NoOfWheels";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "model_desc" : "Model";


            switch (sortOrder)
            {
                case "reg_desc":
                    model = model.OrderByDescending(s => s.RegNumber).ToList();

                    break;
                case "Color":
                    model = model.OrderBy(s => s.Colour).ToList();
                    break;
                case "color_desc":
                    model = model.OrderByDescending(s => s.Colour).ToList();
                    break;
                case "NoOfWheels":
                    model = model.OrderBy(s => s.NoOfWheels).ToList();
                    break;
                case "wheels_desc":
                    model = model.OrderByDescending(s => s.NoOfWheels).ToList();
                    break;
                case "Brand":
                    model = model.OrderBy(s => s.Brand).ToList();
                    break;
                case "brand_desc":
                    model = model.OrderByDescending(s => s.Brand).ToList();
                    break;
                case "Model":
                    model = model.OrderBy(s => s.Model).ToList();
                    break;
                case "model_desc":
                    model = model.OrderByDescending(s => s.Model).ToList();
                    break;
                default:
                    model = model.OrderBy(s => s.RegNumber).ToList();
                    break;
            }


            if (Request.IsAjaxRequest())
            {
                return PartialView("Search", model);
            }

            return View(model);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}