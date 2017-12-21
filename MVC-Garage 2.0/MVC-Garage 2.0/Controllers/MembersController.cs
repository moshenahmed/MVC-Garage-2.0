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
    public class MembersController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: Members
        public ActionResult Index()
        {
            var model = db.Members.ToList();
            if (model == null)
            {
                ViewBag.Message = "MemberListEmpty";
                return View(ViewBag.Message);
            }
            else { return View(model); }
            
        }

        public ActionResult SearchMember(Member member)
        {
            var model = db.Members.Where(s => s.Personnumber == member.Personnumber).ToList();
            return View(model);
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Personnumber,FirstName,LastName,Address,TelephoneNumber,DateOfBirth")] Member member)
        {
            if (ModelState.IsValid)
            {
                var query = db.Members.Where(s => s.Personnumber == member.Personnumber);
                if (query.Count() == 0) { 
                
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "MemberExists";
                    return View(ViewBag.Message);
                }

            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Personnumber,FirstName,LastName,Address,TelephoneNumber,DateOfBirth")] Member member)
        {
            if (ModelState.IsValid)
            {
                var query = db.Members.Where(s => s.Personnumber == member.Personnumber);
                if (query.Count()  == 0)
                {
                    db.Entry(member).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "MemberExists";
                    return View(ViewBag.Message);
                }
               
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            var vehicleCount = member.ParkedVehicles.Count();
            if (vehicleCount == 0)
            {
                db.Members.Remove(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return Content("The member has parked vehicles. Can not delete");
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
