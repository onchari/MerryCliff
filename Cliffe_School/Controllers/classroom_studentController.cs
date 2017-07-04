using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cliffe_School.Models;

namespace Cliffe_School.Controllers
{
    public class classroom_studentController : Controller
    {
        private merry_cliff_academyEntities1 db = new merry_cliff_academyEntities1();

        // GET: classroom_student
        public ActionResult Index()
        {
            var classroom_student = db.classroom_student.Include(c => c.student);
            return View(classroom_student.ToList());
        }

        // GET: classroom_student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom_student classroom_student = db.classroom_student.Find(id);
            if (classroom_student == null)
            {
                return HttpNotFound();
            }
            return View(classroom_student);
        }

        // GET: classroom_student/Create
        public ActionResult Create()
        {
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email");
            return View();
        }

        // POST: classroom_student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "classroom_id,student_id")] classroom_student classroom_student)
        {
            if (ModelState.IsValid)
            {
                db.classroom_student.Add(classroom_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.student_id = new SelectList(db.students, "student_Id", "email", classroom_student.student_id);
            return View(classroom_student);
        }

        // GET: classroom_student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom_student classroom_student = db.classroom_student.Find(id);
            if (classroom_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email", classroom_student.student_id);
            return View(classroom_student);
        }

        // POST: classroom_student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "classroom_id,student_id")] classroom_student classroom_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroom_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email", classroom_student.student_id);
            return View(classroom_student);
        }

        // GET: classroom_student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom_student classroom_student = db.classroom_student.Find(id);
            if (classroom_student == null)
            {
                return HttpNotFound();
            }
            return View(classroom_student);
        }

        // POST: classroom_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            classroom_student classroom_student = db.classroom_student.Find(id);
            db.classroom_student.Remove(classroom_student);
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
