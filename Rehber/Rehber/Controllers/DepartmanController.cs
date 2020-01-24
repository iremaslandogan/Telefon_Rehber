using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rehber.Models;

namespace Rehber.Controllers
{
    public class DepartmanController : Controller
    {
        private Rehber_DBEntities1 db = new Rehber_DBEntities1();

        // GET: Departman
        public ActionResult Index()
        {
            return View(db.tblDepartman.ToList());
        }

        // GET: Departman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            tblDepartman tblDepartman = db.tblDepartman.Find(id);
            if (tblDepartman == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartman);
        }

        // GET: Departman/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmanID,DepartmanAd")] tblDepartman tblDepartman)
        {
            if (ModelState.IsValid)
            {
                db.tblDepartman.Add(tblDepartman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDepartman);
        }

        // GET: Departman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            tblDepartman tblDepartman = db.tblDepartman.Find(id);
            if (tblDepartman == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartman);
        }

        // POST: Departman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDepartman tblDepartman = db.tblDepartman.Find(id);
            var tblCalisan = (from m in db.tblCalisan
                              where m.Departman == id
                              select m).FirstOrDefault();

            if (tblCalisan == null)
            {
                db.tblDepartman.Remove(tblDepartman);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Message="Departmana bağlı çalışan varsa departmanı silemezsiniz. İlk önce çalışanları başka bir departmana taşıyın.";
                return View();
            }

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
