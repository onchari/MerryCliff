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
    public class exam_resultsController : Controller
    {
        private merry_cliff_academyEntities1 db = new merry_cliff_academyEntities1();

        // GET: exam_results
        public ActionResult Index()
        {
            var exam_results = db.exam_results.Include(e => e.course).Include(e => e.student);
            return View(exam_results.ToList());
        }

        // GET: exam_results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_results exam_results = db.exam_results.Find(id);
            if (exam_results == null)
            {
                return HttpNotFound();
            }
            return View(exam_results);
        }

        // GET: exam_results/Create
        public ActionResult Create()
        {
            ViewBag.course_id = new SelectList(db.courses, "course_id", "name");
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email");
            return View();
        }

        // POST: exam_results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exam_id,student_id,course_id,marks")] exam_results exam_results)
        {
            if (ModelState.IsValid)
            {
                db.exam_results.Add(exam_results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.courses, "course_id", "name", exam_results.course_id);
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email", exam_results.student_id);
            return View(exam_results);
        }

        // GET: exam_results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_results exam_results = db.exam_results.Find(id);
            if (exam_results == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.courses, "course_id", "name", exam_results.course_id);
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email", exam_results.student_id);
            return View(exam_results);
        }

        // POST: exam_results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exam_id,student_id,course_id,marks")] exam_results exam_results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.courses, "course_id", "name", exam_results.course_id);
            ViewBag.student_id = new SelectList(db.students, "student_Id", "email", exam_results.student_id);
            return View(exam_results);
        }

        // GET: exam_results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_results exam_results = db.exam_results.Find(id);
            if (exam_results == null)
            {
                return HttpNotFound();
            }
            return View(exam_results);
        }

        // POST: exam_results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exam_results exam_results = db.exam_results.Find(id);
            db.exam_results.Remove(exam_results);
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
