using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AddressbookApp.Models;

namespace AddressbookApp.Controllers
{
    public class ManageUserdetailsController : Controller
    {
        private ContactManagerEntities db = new ContactManagerEntities();

        // GET: ManageUserdetails
        public ActionResult Index()
        {
            return View(db.Userdetails.ToList());
        }

        // GET: ManageUserdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdetail userdetail = db.Userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // GET: ManageUserdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageUserdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PKUserId,UserName,Password,FirstName,LastName,EmailId,PhoneNo,IsActive")] Userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.Userdetails.Add(userdetail);
                db.SaveChanges();
                return RedirectToAction("LogOn","Login");
            }

            return View(userdetail);
        }

        // GET: ManageUserdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdetail userdetail = db.Userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // POST: ManageUserdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PKUserId,UserName,Password,FirstName,LastName,EmailId,PhoneNo,IsActive")] Userdetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdetail);
        }

        // GET: ManageUserdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdetail userdetail = db.Userdetails.Find(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }

        // POST: ManageUserdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userdetail userdetail = db.Userdetails.Find(id);
            db.Userdetails.Remove(userdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
