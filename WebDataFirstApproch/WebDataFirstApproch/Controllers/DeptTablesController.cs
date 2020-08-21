using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDataFirstApproch;

namespace WebDataFirstApproch.Controllers
{
    public class DeptTablesController : Controller
    {
        private julDotNetBatch2020Entities db = new julDotNetBatch2020Entities();

        // GET: DeptTables
        public ActionResult Index()
        {
            return View(db.DeptTables.ToList());
        }

        // GET: DeptTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptTable deptTable = db.DeptTables.Find(id);
            if (deptTable == null)
            {
                return HttpNotFound();
            }
            return View(deptTable);
        }

        // GET: DeptTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeptTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptId,DeptName")] DeptTable deptTable)
        {
            if (ModelState.IsValid)
            {
                db.DeptTables.Add(deptTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deptTable);
        }

        // GET: DeptTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptTable deptTable = db.DeptTables.Find(id);
            if (deptTable == null)
            {
                return HttpNotFound();
            }
            return View(deptTable);
        }

        // POST: DeptTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptId,DeptName")] DeptTable deptTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deptTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deptTable);
        }

        // GET: DeptTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeptTable deptTable = db.DeptTables.Find(id);
            if (deptTable == null)
            {
                return HttpNotFound();
            }
            return View(deptTable);
        }

        // POST: DeptTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeptTable deptTable = db.DeptTables.Find(id);
            db.DeptTables.Remove(deptTable);
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
