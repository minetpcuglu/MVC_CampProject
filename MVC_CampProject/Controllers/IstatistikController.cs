using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Statistic
        Istatistik istatistik = new Istatistik();
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            istatistik.TotalCategoryCount = cm.GetList().Count;
            var categoryOfSoftWareHeader = cm.GetByName("yazılım");
            istatistik.SoftwareHeaderCount = hm.Get(categoryOfSoftWareHeader.CategoryID).Count;
            istatistik.WriterCount = wm.GetList().Count;
            istatistik.NumericalDifferances = cm.StatusIsTrue().Count - cm.StatusIsFalse().Count;
            var list = hm.CategoryNameWithMaximumTitles();//en fazla baslıga sahip kategori adı
            foreach (var max in list)
            {
                var ctgr = cm.GetById(max.CategoryID);
                istatistik.CategoryNameWithMaximumTitles = ctgr.CategoryName;
            }
            return View(istatistik);
        }


      
    }
}