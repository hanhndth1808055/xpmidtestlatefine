using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentT1809ELateFine.Models;

namespace AssignmentT1809ELateFine.Controllers
{
    public class LateFinesController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: LateFines
        public ActionResult Index()
        {
            return View(db.LateFines.ToList());
        }

        // GET: LateFines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LateFine lateFine = db.LateFines.Find(id);
            if (lateFine == null)
            {
                return HttpNotFound();
            }
            return View(lateFine);
        }

        public ActionResult AjaxFineSummary()
        {
            ViewBag.TotalFines = db.LateFines.Where(l=>l.DisciplineType == DisciplineTypes.Fine).Sum(l=>l.DisciplineAmount);
            ViewBag.TotalPushUps = db.LateFines.Where(l => l.DisciplineType == DisciplineTypes.PushUps).Sum(l => l.DisciplineAmount);
            
            return PartialView();
        }

        // GET: LateFines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LateFines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNumber,DisciplineType,DisciplineAmount,SubmitTime")] LateFine lateFine)
        {
            if (ModelState.IsValid)
            {
                lateFine.SubmitTime = DateTime.Now;
                db.LateFines.Add(lateFine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lateFine);
        }

        // GET: LateFines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LateFine lateFine = db.LateFines.Find(id);
            if (lateFine == null)
            {
                return HttpNotFound();
            }
            return View(lateFine);
        }

        // POST: LateFines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNumber,DisciplineType,DisciplineAmount,SubmitTime")] LateFine lateFine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lateFine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lateFine);
        }

        // GET: LateFines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LateFine lateFine = db.LateFines.Find(id);
            if (lateFine == null)
            {
                return HttpNotFound();
            }
            return View(lateFine);
        }

        // POST: LateFines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LateFine lateFine = db.LateFines.Find(id);
            db.LateFines.Remove(lateFine);
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
