using MVC_Garage_2._0.DataAccessLayer;
using MVC_Garage_2._0.Models;
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
            IQueryable<ParkedVehicleDetail> vehicles = from v in db.ParkedVehicles
                                                       select new ParkedVehicleDetail
                                                       {
                                                           Id = v.Id,
                                                           RegNumber = v.RegNumber,
                                                           Colour = v.Colour,
                                                           Model = v.Model,
                                                           Brand = v.Brand,
                                                           NoOfWheels = v.NoOfWheels,
                                                           CheckIn = v.CheckIn,
                                                           Type = v.VehicleType.Name,
                                                           Owner = v.Member.FirstName + " " + v.Member.LastName,
                                                       };

            var model = vehicles.GroupBy(v => DbFunctions.TruncateTime(v.CheckIn))
                .Select(g => new ParkByDay
                {
                    Date = (DateTime)g.Key,
                    Count = g.Count(),
                    VehicleList = g.ToList()
                });
            return View(model);
        }
    }
}