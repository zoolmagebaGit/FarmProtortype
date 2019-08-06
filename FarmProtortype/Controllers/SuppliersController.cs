using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmProtortype.Models;

namespace FarmProtortype.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Suppliers
        public ActionResult Index()
        {

            return View(db.Suppliers.ToList());
        }
        public ActionResult GetSuppliers()
        {
            using(ApplicationDbContext db= new ApplicationDbContext())
            {
                var suppliers = db.Suppliers.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = suppliers }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var v = db.Suppliers.Where(a => a.SupplierID == Id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(Supplier sup)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using(ApplicationDbContext db=new ApplicationDbContext())
                {
                    if (sup.SupplierID > 0)
                    {
                        //Edit
                        var v = db.Suppliers.Where(a => a.SupplierID == sup.SupplierID).FirstOrDefault();
                        if (v != null)
                        {
                            v.FirstName = sup.FirstName;
                            v.Surname = sup.Surname;
                            v.EmailAddress = sup.EmailAddress;
                            v.Address = sup.Address;
                            v.Province = sup.Province;
                            v.Comment = sup.Comment;
                        }
                    }
                    else
                    {
                        //save
                        db.Suppliers.Add(sup);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };

        }

        [HttpGet]
        public ActionResult DeleteSup(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var v = db.Suppliers.Where(a => a.SupplierID == Id).FirstOrDefault();
                if (v != null)
                {

                    return View(v);
                }
                else
                {
                    return HttpNotFound();

                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteSupplier(int Id)
        {
            bool status = false;
            using(ApplicationDbContext db=new ApplicationDbContext())
            {
                var v = db.Suppliers.Where(a => a.SupplierID == Id).FirstOrDefault();
                if (v != null)
                {
                    db.Suppliers.Remove(v);
                    db.SaveChanges();
                    status = true;

                }

            }
            return new JsonResult { Data = new { status = status } };

        }
        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,FirstName,Surname,EmailAddress,Address,Type,Province,Comment")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,FirstName,Surname,EmailAddress,Address,Type,Province,Comment")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
