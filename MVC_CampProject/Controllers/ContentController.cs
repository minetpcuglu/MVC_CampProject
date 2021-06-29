using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal());
       
       



        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                cm.GetList();
            }
          
                var deger = cm.GetListAra(p);
                return View(deger);
           
           
           
            
        }

        public ActionResult ContentByHeading(int id) //SOLİD her sınıf kendisine ait işlemleri yapsın  baslıkla alakalı değil içerikle alakalı //içerikleri baslıga göre getir
        {
            var deger = cm.GetListHeadingID(id);
            return View(deger);
        }
    }
}