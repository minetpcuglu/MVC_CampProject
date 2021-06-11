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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());  //ilişkili tabloları cekmek şçşn
        WriterManager wm = new WriterManager(new EfWriterDal());        //ilişkili tabloları cekmek şçşn
        public ActionResult Index()
        {
            var deger = hm.GetList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult HeadingAdd()
        {

            //DROPDOWNLİST   categoriler için 
            //ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueCategory = (from x in cm.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.CategoryName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.CategoryID.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList() ;

            ViewBag.vic = ValueCategory;  //tasımak için 


            //DROPDOWNLİST   yazar için 
            List<SelectListItem> ValueWriter = (from x in wm.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.UserName + " " + x.WriterSurname ,      //display number ise secilen degerin görüntüsü text olan metin girer 
                                                      Value = x.WriterID.ToString()  //valuenumber = secilen degerin ıd si
                                                  }).ToList();

            ViewBag.a = ValueWriter;  //tasımak için 

            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdd(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //tarihi ındex kısmında eklemek istemiyorsak
            hm.HeadingAdd(h);
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public ActionResult UpdateHeadingPage(int id)
        {
            //DROPDOWNLİST   categoriler için 
            //ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueCategory = (from x in cm.GetList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.CategoryName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.CategoryID.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueCategory;  //tasımak için 



            var deger = hm.GetById(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateHeadingPage(Heading p)
        {
          
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingDelete(int id)
        {
            //durumu false true yapmak için
            var deger = hm.GetById(id); //ıd ye göre bul
            deger.HeadingStatus = false;
            hm.HeadingDelete(deger);

            return RedirectToAction("Index");
        }
    }
}