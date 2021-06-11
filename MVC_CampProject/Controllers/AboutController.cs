using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal()); 
        // GET: About
        public ActionResult Index()
        {
            var deger = abm.GetList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AboutAdd(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        //about için SOLİD prensiplerini Aynı sayfada hem listeleme hem ekleme olmaması için partial view ile yapma
        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }

        public ActionResult ChangeStatus(int id)
        {
            var deger = abm.GetById(id);
            if (deger.AboutStatus==true)
            {
                deger.AboutStatus = false;
            }
            else
            {
                deger.AboutStatus = true;
            }
            abm.AboutUpdate(deger);
            return RedirectToAction("Index");

        }

        
    }
}