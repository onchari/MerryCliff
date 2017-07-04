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
    public class classroomsController : Controller
    {
        private merry_cliff_academyEntities1 db = new merry_cliff_academyEntities1();

        // GET: classrooms
        public ActionResult Index()
        {
            var classrooms = db.classrooms.Include(c => c.grade).Include(c => c.teacher);
            return View(classrooms.ToList());
        }

        // GET: classrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // GET: classrooms/Create
        public ActionResult Create()
        {
            ViewBag.grade_id = new SelectList(db.grades, "grade_id", "name");
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "email");
            return View();
        }

        // POST: classrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "classroom_id,year,grade_id,section,status,remarks,teacher_id")] classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.classrooms.Add(classroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.grade_id = new SelectList(db.grades, "grade_id", "name", classroom.grade_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "email", classroom.teacher_id);
            return View(classroom);
        }

        // GET: classrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.grade_id = new SelectList(db.grades, "grade_id", "name", classroom.grade_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "email", classroom.teacher_id);
            return View(classroom);
        }

        // POST: classrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "classroom_id,year,grade_id,section,status,remarks,teacher_id")] classroom classroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.grade_id = new SelectList(db.grades, "grade_id", "name", classroom.grade_id);
            ViewBag.teacher_id = new SelectList(db.teachers, "teacher_id", "email", classroom.teacher_id);
            return View(classroom);
        }

        // GET: classrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            classroom classroom = db.classrooms.Find(id);
            db.classrooms.Remove(classroom);
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
