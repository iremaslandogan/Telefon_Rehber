using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Rehber.Models;

namespace Rehber.Controllers
{
    public class LoginController : Controller
    {
        private Rehber_DBEntities1 db = new Rehber_DBEntities1();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblAdmin login)
        {
            if (ModelState.IsValid)
            {
                using (Rehber_DBEntities1 db = new Rehber_DBEntities1())
                {
                    var obj = db.tblAdmin.Where(a => a.KullaniciAd.Equals(login.KullaniciAd) && a.Sifre.Equals(login.Sifre)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["KullaniciID"] = login.ID.ToString();
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View(login);
        }
        public ActionResult Logout()
        {
            Session.Remove("KullaniciID");
            return RedirectToAction("Index", "Home");
        }        
    }
}