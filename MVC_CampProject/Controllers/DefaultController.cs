using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    [AllowAnonymous]    //giriş işlemini pasifleştirme 
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var deger = hm.GetList();
            return View(deger);
        }
        public PartialViewResult IndexPartial(int id=0) //baslık boş gelmesin diye 0 ladık 
        {
            var deger = cm.GetListHeadingID(id);
            return PartialView(deger);
        }
    }
}