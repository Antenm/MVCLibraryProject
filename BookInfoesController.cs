using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookProject.Models;

namespace BookProject.Controllers
{
    public class BookInfoesController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        // GET: BookInfoes
        public ActionResult Index()
        {
            return View(db.BookInfo.ToList());
        }

        // GET: BookInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfo.Find(id);
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookInfo);
        }

        // GET: BookInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Author,YearReleased,ISBN,BookPrice")] BookInfo bookInfo)
        {
            if (ModelState.IsValid)
            {
                db.BookInfo.Add(bookInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookInfo);
        }

        // GET: BookInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfo.Find(id);
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookInfo);
        }

        // POST: BookInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Author,YearReleased,ISBN,BookPrice")] BookInfo bookInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookInfo);
        }

        // GET: BookInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInfo bookInfo = db.BookInfo.Find(id);
            if (bookInfo == null)
            {
                return HttpNotFound();
            }
            return View(bookInfo);
        }

        // POST: BookInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BookInfo bookInfo = db.BookInfo.Find(id);
            db.BookInfo.Remove(bookInfo);
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
