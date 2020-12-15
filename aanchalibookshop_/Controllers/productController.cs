using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aanchalibookshop_;

namespace aanchalibookshop_.Controllers
{
    public class productController : Controller
    {
        private aanchalbookshop_Entities1 db = new aanchalbookshop_Entities1();

        // GET: product
        public ActionResult Index()
        {
            var productdetails = db.productdetails.Include(p => p.category);
            return View(productdetails.ToList());
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productdetail productdetail = db.productdetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.categories, "cat_id", "cat_name");
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_id,p_name,p_price,p_qty,p_detail,cat_id")] productdetail productdetail)
        {
            if (ModelState.IsValid)
            {
                db.productdetails.Add(productdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.categories, "cat_id", "cat_name", productdetail.cat_id);
            return View(productdetail);
        }

        // GET: product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productdetail productdetail = db.productdetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.categories, "cat_id", "cat_name", productdetail.cat_id);
            return View(productdetail);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_id,p_name,p_price,p_qty,p_detail,cat_id")] productdetail productdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.categories, "cat_id", "cat_name", productdetail.cat_id);
            return View(productdetail);
        }

        // GET: product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productdetail productdetail = db.productdetails.Find(id);
            if (productdetail == null)
            {
                return HttpNotFound();
            }
            return View(productdetail);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productdetail productdetail = db.productdetails.Find(id);
            db.productdetails.Remove(productdetail);
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
