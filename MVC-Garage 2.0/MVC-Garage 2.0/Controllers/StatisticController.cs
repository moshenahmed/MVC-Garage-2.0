using MVC_Garage_2._0.DataAccessLayer;
using MVC_Garage_2._0.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Garage_2._0.Controllers
{
    public class StatisticController : Controller
    {
        private RegisterContext db = new RegisterContext();
        // GET: Statistic
        public ActionResult Index()
        {
            var model = db.ParkedVehicles.GroupBy(v => DbFunctions.TruncateTime(v.CheckIn))
                .Select(g => new ParkByDay
                {
                    Date = (DateTime)g.Key,
                    Count = g.Count(),
                    VehicleList = g
                }).ToList();
            return View(model);
        }
    }
}