using DataAccessLayer.Concrete;
using MVC_CampProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class ChartController : Controller
    {
        Context c = new Context();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult WriterChart()
        {
            return Json(BlogList3(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        }

        public ActionResult HeadingChart()
        {
            return Json(BlogList2(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        }


        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet); //kullanılma izin ver 
        }

        public List<CategoryVM> BlogList()
        {
            List<CategoryVM> categoryVMs = new List<CategoryVM>();
            categoryVMs = c.Categories.Select(x => new CategoryVM
            {
                CategoryName = x.CategoryName,
                CategoryCount = x.headings.Count,

            }).ToList();
            
            return categoryVMs;
        }
        public List<HeadingVM> BlogList2()
        {
            List<HeadingVM> headingVMs = new List<HeadingVM>();
            headingVMs = c.Headings.Select(x => new HeadingVM
            {
                HeadingName = x.HeadingName,
                ContentCount = x.contents.Count,

            }).ToList();

            return headingVMs ;
        }
        public List<WriterVM> BlogList3()
        {
            List<WriterVM> writerVMs = new List<WriterVM>();
            writerVMs = c.Writers.Select(x => new WriterVM
            {
                WriterName = x.UserName,
                HeadingCount = x.headings.Count,

            }).ToList();

            return writerVMs ;
        }
    }
}