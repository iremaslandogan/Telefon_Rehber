using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Rehber.Models;
using System.Net;

namespace Rehber.Controllers
{
    public class HomeController : Controller
    {
        private Rehber_DBEntities1 db = new Rehber_DBEntities1();
        public ActionResult Index()
        {
            var tblCalisan = db.tblCalisan.Include(t => t.tblCalisan2).Include(t => t.tblDepartman);
            return View(tblCalisan.ToList());
        }
        // GET: Calisan/CalisanDetay/5
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
        
    }
}