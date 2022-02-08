using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Raklet.Models.EntityDataModel;

namespace Raklet.Controllers
{
    public class SOLUTIONController : Controller
    {
        private StackOverflowEntities db = new StackOverflowEntities();

        // GET: SOLUTION
        public ActionResult Index()
        {
            var sOLUTION = db.SOLUTION.Include(s => s.SUBJECT);
            return View(sOLUTION.ToList());
        }

        // GET: SOLUTION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLUTION sOLUTION = db.SOLUTION.Find(id);
            if (sOLUTION == null)
            {
                return HttpNotFound();
            }
            return View(sOLUTION);
        }

        // GET: SOLUTION/Create
        public ActionResult Create()
        {
            ViewBag.SUBID = new SelectList(db.SUBJECT, "SUBJECT_ID", "PROBLEM");
            return View();
        }

        // POST: SOLUTION/Create 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SOLUTION_ID,NAME_SURENAME,E_MAIL,SOLUTION1,SUBID")] SOLUTION sOLUTION)
        {
            if (ModelState.IsValid)
            {
                db.SOLUTION.Add(sOLUTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SUBID = new SelectList(db.SUBJECT, "SUBJECT_ID", "PROBLEM", sOLUTION.SUBID);
            return View(sOLUTION);
        }

        // GET: SOLUTION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLUTION sOLUTION = db.SOLUTION.Find(id);
            if (sOLUTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.SUBID = new SelectList(db.SUBJECT, "SUBJECT_ID", "PROBLEM", sOLUTION.SUBID);
            return View(sOLUTION);
        }

        // POST: SOLUTION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SOLUTION_ID,NAME_SURENAME,E_MAIL,SOLUTION1,SUBID")] SOLUTION sOLUTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLUTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SUBID = new SelectList(db.SUBJECT, "SUBJECT_ID", "PROBLEM", sOLUTION.SUBID);
            return View(sOLUTION);
        }

        // GET: SOLUTION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLUTION sOLUTION = db.SOLUTION.Find(id);
            if (sOLUTION == null)
            {
                return HttpNotFound();
            }
            return View(sOLUTION);
        }

        // POST: SOLUTION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLUTION sOLUTION = db.SOLUTION.Find(id);
            db.SOLUTION.Remove(sOLUTION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
