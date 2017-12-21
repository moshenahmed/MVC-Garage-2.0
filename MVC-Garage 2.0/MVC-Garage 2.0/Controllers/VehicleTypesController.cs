using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Garage_2._0.DataAccessLayer;
using MVC_Garage_2._0.Models;

namespace MVC_Garage_2._0.Controllers
{
    public class VehicleTypesController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: VehicleTypes
        public ActionResult Index()
        {
            return View(db.VehicleTypes.ToList());
        }


        // POST: VehicleTypes/Index/?TypeName=
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string TypeName)
        {
            if (String.IsNullOrEmpty(TypeName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = new VehicleType(TypeName);
            if (ModelState.IsValid)
            {
                db.VehicleTypes.Add(vehicleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            var vehicleCount = vehicleType.ParkedVehicles.Count();
            if (vehicleCount == 0)
            {
                db.VehicleTypes.Remove(vehicleType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Content("The vehicle type has parked vehicles. Can not delete");
            }
            
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
