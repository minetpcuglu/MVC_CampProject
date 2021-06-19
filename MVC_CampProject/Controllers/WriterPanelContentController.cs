using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        //içeriklerim 
        public ActionResult MyContent(string p) //SOLİD her sınıf kendisine ait işlemleri yapsın  baslıkla alakalı değil içerikle alakalı //içerikleri baslıga göre getir
        {
           
         

            p =(string)
            Session["WriterMail"];  //sisteme giriş yaptıgın mail id gerekiyor
            //sisteme kimle giriş yaptıysa onun bilgileri getirir 
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var deger = cm.GetListWriterID(writeridinfo);
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
           string mail= (string) Session["WriterMail"];  //sisteme giriş yaptıgın mail id gerekiyor
            //sisteme kimle giriş yaptıysa onun bilgileri getirir 
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            p.ContentDate = DateTime.Parse( DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);

            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()  //yapılacaklar listesi
        {
            return View();
        }
    }
}