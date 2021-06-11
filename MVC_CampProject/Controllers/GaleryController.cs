using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        ImageFileManager IFM = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var deger = IFM.GetList();
            return View(deger);
        }
    }
}