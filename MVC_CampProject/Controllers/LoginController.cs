using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CampProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
     
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin ad)  //kullanıcı giriş kısmını ayarlama 
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.AdminUserName == ad.AdminUserName && x.AdminPassword == ad.AdminPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminUserName, false);
                Session["AdminUserName"] = bilgiler.AdminUserName.ToString();
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}