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
    public class TestFaceCreamsController : Controller
    {
        private MyDatabase db = new MyDatabase();

        // GET: TestFaceCreams
        public ActionResult Index()
        {
            return View(db.FaceCreams.ToList());
        }

        // GET: TestFaceCreams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaceCream faceCream = (FaceCream)db.Products.Find(id);
            if (faceCream == null)
            {
                return HttpNotFound();
            }
            return View(faceCream);
        }

        // GET: TestFaceCreams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestFaceCreams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Title,ImageURL,Directions,Incredient")] FaceCream faceCream)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(faceCream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faceCream);
        }

        // GET: TestFaceCreams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaceCream faceCream = (FaceCream)db.Products.Find(id);
            if (faceCream == null)
            {
                return HttpNotFound();
            }
            return View(faceCream);
        }

        // POST: TestFaceCreams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Title,ImageURL,Directions,Incredient")] FaceCream faceCream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faceCream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faceCream);
        }

        // GET: TestFaceCreams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaceCream faceCream = (FaceCream)db.Products.Find(id);
            if (faceCream == null)
            {
                return HttpNotFound();
            }
            return View(faceCream);
        }

        // POST: TestFaceCreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FaceCream faceCream = (FaceCream)db.Products.Find(id);
            db.Products.Remove(faceCream);
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
