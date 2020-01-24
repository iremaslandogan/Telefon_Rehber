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
    public class CalisanController : Controller
    {
        private Rehber_DBEntities1 db = new Rehber_DBEntities1();

        // GET: Calisan
        public ActionResult Index()
        {
            var tblCalisan = db.tblCalisan.Include(t => t.tblCalisan2).Include(t => t.tblDepartman);
            return View(tblCalisan.ToList());
        }

        // GET: Calisan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            tblCalisan tblCalisan = db.tblCalisan.Find(id);
            if (tblCalisan == null)
            {
                return HttpNotFound();
            }
            return View(tblCalisan);
        }

        // GET: Calisan/Create
        public ActionResult Create()
        {
            ViewBag.Yonetici = new SelectList(db.tblCalisan, "CalisanID", "Ad");
            ViewBag.Departman = new SelectList(db.tblDepartman, "DepartmanID", "DepartmanAd");
            return View();
        }

        // POST: Calisan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalisanID,Ad,Soyad,Telefon,Departman,Yonetici")] tblCalisan tblCalisan)
        {
            if (ModelState.IsValid)
            {
                db.tblCalisan.Add(tblCalisan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Yonetici = new SelectList(db.tblCalisan, "CalisanID", "Ad", tblCalisan.Yonetici);
            ViewBag.Departman = new SelectList(db.tblDepartman, "DepartmanID", "DepartmanAd", tblCalisan.Departman);
            return View(tblCalisan);
        }

        // GET: Calisan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            tblCalisan tblCalisan = db.tblCalisan.Find(id);
            if (tblCalisan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Yonetici = new SelectList(db.tblCalisan, "CalisanID", "Ad", tblCalisan.Yonetici);
            ViewBag.Departman = new SelectList(db.tblDepartman, "DepartmanID", "DepartmanAd", tblCalisan.Departman);
            return View(tblCalisan);
        }

        // POST: Calisan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalisanID,Ad,Soyad,Telefon,Departman,Yonetici")] tblCalisan tblCalisan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCalisan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Yonetici = new SelectList(db.tblCalisan, "CalisanID", "Ad", tblCalisan.Yonetici);
            ViewBag.Departman = new SelectList(db.tblDepartman, "DepartmanID", "DepartmanAd", tblCalisan.Departman);
            return View(tblCalisan);
        }

        // GET: Calisan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            tblCalisan tblCalisan = db.tblCalisan.Find(id);
            if (tblCalisan == null)
            {
                return HttpNotFound();
            }
            return View(tblCalisan);
        }

        // POST: Calisan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCalisan tblCalisan = db.tblCalisan.Find(id);
            var Yonetici = (from m in db.tblCalisan
                              where m.Yonetici == id
                              select m).FirstOrDefault();
            if (Yonetici == null)
            {
                db.tblCalisan.Remove(tblCalisan);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Message = "Çalışan Aynı zamanda bir yönetici ise çalışanı silemezsiniz. İlk önce Çalışanları Başka bir yöneticiye taşıyın.";
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
