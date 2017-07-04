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
    public class exam_typeController : Controller
    {
        private merry_cliff_academyEntities1 db = new merry_cliff_academyEntities1();

        // GET: exam_type
        public ActionResult Index()
        {
            return View(db.exam_type.ToList());
        }

        // GET: exam_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_type exam_type = db.exam_type.Find(id);
            if (exam_type == null)
            {
                return HttpNotFound();
            }
            return View(exam_type);
        }

        // GET: exam_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: exam_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exam_type_id,name,desc")] exam_type exam_type)
        {
            if (ModelState.IsValid)
            {
                db.exam_type.Add(exam_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam_type);
        }

        // GET: exam_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_type exam_type = db.exam_type.Find(id);
            if (exam_type == null)
            {
                return HttpNotFound();
            }
            return View(exam_type);
        }

        // POST: exam_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exam_type_id,name,desc")] exam_type exam_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam_type);
        }

        // GET: exam_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exam_type exam_type = db.exam_type.Find(id);
            if (exam_type == null)
            {
                return HttpNotFound();
            }
            return View(exam_type);
        }

        // POST: exam_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            exam_type exam_type = db.exam_type.Find(id);
            db.exam_type.Remove(exam_type);
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
