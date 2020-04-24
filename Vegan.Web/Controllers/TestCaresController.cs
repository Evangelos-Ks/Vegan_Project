using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vegan.Database;
using Vegan.Entities.Care;

namespace Vegan.Web.Controllers
{
    public class TestCaresController : Controller
    {
        private MyDatabase db = new MyDatabase();

        // GET: TestCares
        public ActionResult Index()
        {
            return View(db.Cares.ToList());
        }

        // GET: TestCares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Care care = (Care)db.Products.Find(id);
            if (care == null)
            {
                return HttpNotFound();
            }
            return View(care);
        }

        // GET: TestCares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestCares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Title,ImageURL,Directions")] Care care)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(care);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(care);
        }

        // GET: TestCares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Care care = (Care)db.Products.Find(id);
            if (care == null)
            {
                return HttpNotFound();
            }
            return View(care);
        }

        // POST: TestCares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Title,ImageURL,Directions")] Care care)
        {
            if (ModelState.IsValid)
            {
                db.Entry(care).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(care);
        }

        // GET: TestCares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Care care = (Care)db.Products.Find(id);
            if (care == null)
            {
                return HttpNotFound();
            }
            return View(care);
        }

        // POST: TestCares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Care care = (Care)db.Products.Find(id);
            db.Products.Remove(care);
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
