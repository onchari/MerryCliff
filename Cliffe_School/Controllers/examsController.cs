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
    public class examsController : Controller
    {
        private merry_cliff_academyEntities1 db = new merry_cliff_academyEntities1();

        // GET: exams
        public ActionResult Index()
        {
            var exams = db.exams.Include(e => e.exam_type);
            return View(exams.ToList());
        }

        // GET: exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: exams/Create
        public ActionResult Create()
        {
            ViewBag.exam_type_id = new SelectList(db.exam_type, "exam_type_id", "name");
            return View();
        }

        // POST: exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exam_id,exam_type_id,name,start_date")] exam exam)
        {
            if (ModelState.IsValid)
            {
                db.exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exam_type_id = new SelectList(db.exam_type, "exam_type_id", "name", exam.exam_type_id);
            return View(exam);
        }

        // GET: exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.exam_type_id = new SelectList(db.exam_type, "exam_type_id", "name", exam.exam_type_id);
            return View(exam);
        }

        // POST: exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exam_id,exam_type_id,name,start_date")] exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exam_type_id = new SelectList(db.exam_type, "exam_type_id", "name", exam.exam_type_id);
            return View(exam);
        }

        // GET: exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam exam = db.exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exam exam = db.exams.Find(id);
            db.exams.Remove(exam);
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
