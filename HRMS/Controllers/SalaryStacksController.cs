using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Models;

namespace HRMS.Controllers
{
    public class SalaryStacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalaryStacks
        public ActionResult Index()
        {
            return View(db.SalaryStacks.ToList());
        }

        // GET: SalaryStacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryStack salaryStack = db.SalaryStacks.Find(id);
            if (salaryStack == null)
            {
                return HttpNotFound();
            }
            return View(salaryStack);
        }

        // GET: SalaryStacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryStacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BasicPay,HomeAllowence,TravelAllowence,VariablePay,BenifitPlan,ProvidentFund,Gratuty,HealthBenifit")] SalaryStack salaryStack)
        {
            if (ModelState.IsValid)
            {
                db.SalaryStacks.Add(salaryStack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryStack);
        }

        // GET: SalaryStacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryStack salaryStack = db.SalaryStacks.Find(id);
            if (salaryStack == null)
            {
                return HttpNotFound();
            }
            return View(salaryStack);
        }

        // POST: SalaryStacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BasicPay,HomeAllowence,TravelAllowence,VariablePay,BenifitPlan,ProvidentFund,Gratuty,HealthBenifit")] SalaryStack salaryStack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryStack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryStack);
        }

        // GET: SalaryStacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryStack salaryStack = db.SalaryStacks.Find(id);
            if (salaryStack == null)
            {
                return HttpNotFound();
            }
            return View(salaryStack);
        }

        // POST: SalaryStacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryStack salaryStack = db.SalaryStacks.Find(id);
            db.SalaryStacks.Remove(salaryStack);
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
