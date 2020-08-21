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
    public class EmployeeTb1Controller : Controller
    {
        private julDotNetBatch2020Entities db = new julDotNetBatch2020Entities();

        // GET: EmployeeTb1
        public ActionResult Index()
        {
            var employeeTb1 = db.EmployeeTb1.Include(e => e.DeptTable);
            return View(employeeTb1.ToList());
        }

        // GET: EmployeeTb1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTb1 employeeTb1 = db.EmployeeTb1.Find(id);
            if (employeeTb1 == null)
            {
                return HttpNotFound();
            }
            return View(employeeTb1);
        }

        // GET: EmployeeTb1/Create
        public ActionResult Create()
        {
            ViewBag.deptid = new SelectList(db.DeptTables, "DeptId", "DeptName");
            return View();
        }

        // POST: EmployeeTb1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empId,empName,empSal,deptid")] EmployeeTb1 employeeTb1)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTb1.Add(employeeTb1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.deptid = new SelectList(db.DeptTables, "DeptId", "DeptName", employeeTb1.deptid);
            return View(employeeTb1);
        }

        // GET: EmployeeTb1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTb1 employeeTb1 = db.EmployeeTb1.Find(id);
            if (employeeTb1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.deptid = new SelectList(db.DeptTables, "DeptId", "DeptName", employeeTb1.deptid);
            return View(employeeTb1);
        }

        // POST: EmployeeTb1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empId,empName,empSal,deptid")] EmployeeTb1 employeeTb1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTb1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptid = new SelectList(db.DeptTables, "DeptId", "DeptName", employeeTb1.deptid);
            return View(employeeTb1);
        }

        // GET: EmployeeTb1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTb1 employeeTb1 = db.EmployeeTb1.Find(id);
            if (employeeTb1 == null)
            {
                return HttpNotFound();
            }
            return View(employeeTb1);
        }

        // POST: EmployeeTb1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTb1 employeeTb1 = db.EmployeeTb1.Find(id);
            db.EmployeeTb1.Remove(employeeTb1);
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
