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
    public class AdminController : Controller
    {
        private Rehber_DBEntities1 db = new Rehber_DBEntities1();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.tblAdmin.ToList());
        }


        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            tblAdmin tblAdmin = db.tblAdmin.Find(id);
            if (tblAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tblAdmin);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KullaniciAd,Sifre")] tblAdmin tblAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAdmin);
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
