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
        public ActionResult Index(int page = 1)
        {
            var listVehicles = new List<ParkedVehicleOverview>();
            foreach (var v in db.ParkedVehicles.OrderBy(p => p.RegNumber).Skip(PageSize * (page - 1)).Take(PageSize).ToList())
            {
                ParkedVehicleOverview ov = new ParkedVehicleOverview(v);
                ov.Owner = v.Member.FirstName + " " + v.Member.LastName;
                ov.Type = v.VehicleType.Name;
                listVehicles.Add(ov);
            }
            var model = new PagedVehicle();
            model.Data = listVehicles;
            model.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)db.ParkedVehicles.Count() / PageSize));
            model.CurrentPage = page;
            if (Request.IsAjaxRequest())
            {
                return PartialView("PagedVehicleList", model);
            }
            else return View(model);
        }

        public ActionResult ListByOwner()
        {
            return View(db.ParkedVehicles.ToList());
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

            var detail = new ParkedVehicleDetail(parkedVehicle);
            return View(detail);
        }

        // GET: ParkedVehicles/Park
        //https://www.codeproject.com/Articles/1130342/Best-ways-of-implementing-Uniqueness-or-Unique-Key
        public ActionResult Park()
        {
            ViewBag.Type = new SelectList(db.VehicleTypes, "Id", "Name");
            return View();
        }

        // POST: ParkedVehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,Type,Owner,RegNumber,Colour,Brand,Model,NoOfWheels")] ParkedVehicleDetail vehicleDetail)
        {
            ////server site check for unique RegNum
            //bool IsVehicleExist = db.ParkedVehicles.Any(x => x.RegNumber == parkedVehicle.RegNumber && x.Id != parkedVehicle.Id);
            //if (IsVehicleExist == true)
            //{
            //    ModelState.AddModelError("RegNumber", "Vehicle registration number already exists");
            //}
            ParkedVehicle parkedVehicle = new ParkedVehicle(vehicleDetail);
            ViewBag.Type = new SelectList(db.VehicleTypes, "Id", "Name", vehicleDetail.Type);
            parkedVehicle.TypeId = Int32.Parse(vehicleDetail.Type);

            var members = db.Members.ToList();
            var member = members.FirstOrDefault(x => x.FullName == vehicleDetail.Owner);
            if (member == null)
            {
                ModelState.AddModelError("Owner", "Vehicle Owner is not exist");
            }
            else
                parkedVehicle.MemberId = member.Id;

            if (ModelState.IsValid)
            {
                parkedVehicle.CheckIn = DateTime.Now;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleDetail);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Update(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            ParkedVehicleDetail vehicleDetail = new ParkedVehicleDetail(parkedVehicle);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = new SelectList(db.VehicleTypes, "Id", "Name", parkedVehicle.TypeId);
            return View(vehicleDetail);
        }

        // POST: ParkedVehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Type,Owner,RegNumber,Colour,Brand,Model,NoOfWheels,CheckIn")] ParkedVehicleDetail vehicleDetail)
        {
            //server site check for unique RegNum
            //bool IsVehicleExist = db.ParkedVehicles.Any(x => x.RegNumber == parkedVehicle.RegNumber && x.Id != parkedVehicle.Id);
            //if (IsVehicleExist == true)
            //{
            //    ModelState.AddModelError("RegNumber", "Vehicle registration number already exists");
            //}
            ParkedVehicle parkedVehicle = new ParkedVehicle(vehicleDetail);
            ViewBag.Type = new SelectList(db.VehicleTypes, "Id", "Name", vehicleDetail.Type);
            parkedVehicle.TypeId = Int32.Parse(vehicleDetail.Type);


            var members = db.Members.ToList();
            var member = members.FirstOrDefault(x => x.FullName == vehicleDetail.Owner);
            if (member == null)
            {
                ModelState.AddModelError("Owner", "Vehicle Owner is not exist");
            }
            else
                parkedVehicle.MemberId = member.Id;


            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleDetail);
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
            return View("Receipt", receipt);
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

        public ActionResult AutoComplete(string term)
        {
            var members = db.Members.ToList();
            var model = members.Where(v => v.FirstName.StartsWith(term,StringComparison.CurrentCultureIgnoreCase) || v.LastName.StartsWith(term, StringComparison.CurrentCultureIgnoreCase))
                .Take(10)
                .Select(v => new { label = v.FullName + " ( " + v.Personnumber + ")" });

            return Json(model, JsonRequestBehavior.AllowGet);
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
