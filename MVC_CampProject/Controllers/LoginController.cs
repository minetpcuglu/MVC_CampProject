using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CampProject.Controllers
{

    [AllowAnonymous] //proje bazında olusturulan kurallardan muaf olması için  authourize 
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());
     
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin ad)  //kullanıcı giriş kısmını ayarlama 
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.AdminName == ad.AdminName && x.AdminPassword == ad.AdminPassword);
        
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminName, false);
                Session["AdminName"] = bilgiler.AdminName.ToString();
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
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer a)
        {
            //var bilgiler = c.Writers.FirstOrDefault(x => x.WriterMail == a.WriterMail && x.WriterPassword == a.WriterPassword);
            var bilgiler = writerLoginManager.GetWriter(a.WriterMail , a.WriterPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.WriterMail, false);
                Session["WriterMail"] = bilgiler.WriterMail.ToString();
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
           
        }

    }
}