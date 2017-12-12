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
using MVC_Garage_2._0.Models.ViewModels;

namespace MVC_Garage_2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private RegisterContext db = new RegisterContext();
        public const int PageSize = 5;

        // GET: ParkedVehicles
        public ActionResult Index(int page=1)
        {
            var listVehicles = new List<ParkedVehicleIndexVM>();
            foreach (var v in db.ParkedVehicles.OrderBy(p => p.RegNumber).Skip(PageSize * (page - 1)).Take(PageSize).ToList())
            {
                listVehicles.Add(new ParkedVehicleIndexVM(v));
            }
            var model = new PagedVehicle();
            model.Data = listVehicles;
            model.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)db.ParkedVehicles.Count() / PageSize));
            model.CurrentPage = page;
            if (Request.IsAjaxRequest())
            {
                return PartialView("PagedVehicleList",model);
        }
            else return View(model);
        }


        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Park
        //https://www.codeproject.com/Articles/1130342/Best-ways-of-implementing-Uniqueness-or-Unique-Key
        public ActionResult Park()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,Type,RegNumber,Colour,Brand,Model,NoOfWheels")] ParkedVehicle parkedVehicle)
        {
            ////server site check for unique RegNum
            //bool IsVehicleExist = db.ParkedVehicles.Any(x => x.RegNumber == parkedVehicle.RegNumber && x.Id != parkedVehicle.Id);
            //if (IsVehicleExist == true)
            //{
            //    ModelState.AddModelError("RegNumber", "Vehicle registration number already exists");
            //}

            if (ModelState.IsValid)
            {
                parkedVehicle.CheckIn = DateTime.Now;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Type,RegNumber,Colour,Brand,Model,NoOfWheels,CheckIn")] ParkedVehicle parkedVehicle)
        {
            //server site check for unique RegNum
            //bool IsVehicleExist = db.ParkedVehicles.Any(x => x.RegNumber == parkedVehicle.RegNumber && x.Id != parkedVehicle.Id);
            //if (IsVehicleExist == true)
            //{
            //    ModelState.AddModelError("RegNumber", "Vehicle registration number already exists");
            //}

            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Unpark/5
        public ActionResult Receipt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ReceiptVM receipt = new ReceiptVM(parkedVehicle);
            receipt.CheckOut = DateTime.Now;
            return View("Receipt",receipt);
        }

        //POST: ParkedVehicles/UnPark/5
        [HttpPost, ActionName("Receipt")]
        [ValidateAntiForgeryToken]
        public ActionResult UnparkConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //client site to check if the registration number is already exist
        public JsonResult IsVehicleExist(string RegNumber, int? Id)
        {
            var validateRegNum = db.ParkedVehicles.FirstOrDefault(x => x.RegNumber == RegNumber && x.Id != Id);
            if (validateRegNum != null)
        {
                return Json(false, JsonRequestBehavior.AllowGet);
        }
            else
        {
                return Json(true, JsonRequestBehavior.AllowGet);
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
