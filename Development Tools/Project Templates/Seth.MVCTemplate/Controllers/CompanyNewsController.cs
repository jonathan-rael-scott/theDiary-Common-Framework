using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETMS.Models;

namespace ETMS.Controllers
{
    public class CompanyNewsController : Controller
    {
        private ETMSContext db = new ETMSContext();

        //
        // GET: /CompanyNews/

        public ActionResult Index()
        {
            return View(db.CompanyNews.ToList());
        }

        //
        // GET: /CompanyNews/Details/5

        public ActionResult Details(int id = 0)
        {
            CompanyNews companynews = db.CompanyNews.Find(id);
            if (companynews == null)
            {
                return HttpNotFound();
            }
            return View(companynews);
        }

        //
        // GET: /CompanyNews/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompanyNews/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyNews companynews)
        {
            if (ModelState.IsValid)
            {
                db.CompanyNews.Add(companynews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companynews);
        }

        //
        // GET: /CompanyNews/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CompanyNews companynews = db.CompanyNews.Find(id);
            if (companynews == null)
            {
                return HttpNotFound();
            }
            return View(companynews);
        }

        //
        // POST: /CompanyNews/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyNews companynews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companynews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companynews);
        }

        //
        // GET: /CompanyNews/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CompanyNews companynews = db.CompanyNews.Find(id);
            if (companynews == null)
            {
                return HttpNotFound();
            }
            return View(companynews);
        }

        //
        // POST: /CompanyNews/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyNews companynews = db.CompanyNews.Find(id);
            db.CompanyNews.Remove(companynews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}