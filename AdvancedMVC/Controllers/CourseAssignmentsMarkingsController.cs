using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedMVC.Models;

namespace AdvancedMVC.Controllers
{
    public class CourseAssignmentsMarkingsController : Controller
    {
        private DB2Entities1 db = new DB2Entities1();

        // GET: CourseAssignmentsMarkings
        public ActionResult Index()
        {
            var courseAssignmentsMarking = db.CourseAssignmentsMarking.Include(c => c.Courses).Include(c => c.Staff).Include(c => c.Students);
            return View(courseAssignmentsMarking.ToList());
        }

        // GET: CourseAssignmentsMarkings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssignmentsMarking courseAssignmentsMarking = db.CourseAssignmentsMarking.Find(id);
            if (courseAssignmentsMarking == null)
            {
                return HttpNotFound();
            }
            return View(courseAssignmentsMarking);
        }

        // GET: CourseAssignmentsMarkings/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name");
            ViewBag.MarkerID = new SelectList(db.Staff, "ID", "Name");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name");
            return View();
        }

        // POST: CourseAssignmentsMarkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseID,MarkerID,StudentID")] CourseAssignmentsMarking courseAssignmentsMarking)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssignmentsMarking.Add(courseAssignmentsMarking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", courseAssignmentsMarking.CourseID);
            ViewBag.MarkerID = new SelectList(db.Staff, "ID", "Title", courseAssignmentsMarking.MarkerID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", courseAssignmentsMarking.StudentID);
            return View(courseAssignmentsMarking);
        }

        // GET: CourseAssignmentsMarkings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssignmentsMarking courseAssignmentsMarking = db.CourseAssignmentsMarking.Find(id);
            if (courseAssignmentsMarking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", courseAssignmentsMarking.CourseID);
            ViewBag.MarkerID = new SelectList(db.Staff, "ID", "Title", courseAssignmentsMarking.MarkerID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", courseAssignmentsMarking.StudentID);
            return View(courseAssignmentsMarking);
        }

        // POST: CourseAssignmentsMarkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,MarkerID,StudentID")] CourseAssignmentsMarking courseAssignmentsMarking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseAssignmentsMarking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Name", courseAssignmentsMarking.CourseID);
            ViewBag.MarkerID = new SelectList(db.Staff, "ID", "Title", courseAssignmentsMarking.MarkerID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", courseAssignmentsMarking.StudentID);
            return View(courseAssignmentsMarking);
        }

        // GET: CourseAssignmentsMarkings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssignmentsMarking courseAssignmentsMarking = db.CourseAssignmentsMarking.Find(id);
            if (courseAssignmentsMarking == null)
            {
                return HttpNotFound();
            }
            return View(courseAssignmentsMarking);
        }

        // POST: CourseAssignmentsMarkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssignmentsMarking courseAssignmentsMarking = db.CourseAssignmentsMarking.Find(id);
            db.CourseAssignmentsMarking.Remove(courseAssignmentsMarking);
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
