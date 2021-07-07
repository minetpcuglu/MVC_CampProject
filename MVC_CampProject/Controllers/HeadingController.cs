using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        HeadingValidator rules = new HeadingValidator();


        public ActionResult Index()
        {
            var deger = hm.GetList();
           
           
            return View(deger);
        }

        public ActionResult HeadingReport()
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

            //ValidationResult result = rules.Validate(h);

            //if (result.IsValid)
            //{
                h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //tarihi ındex kısmında eklemek istemiyorsak
                hm.HeadingAdd(h);
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var hata in result.Errors)
            //    {
            //        ModelState.AddModelError(hata.PropertyName, hata.ErrorMessage);
            //    }
            //}
            //return View();



           
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

        public ActionResult WriterByHeading(int id) //SOLİD her sınıf kendisine ait işlemleri yapsın  baslıkla alakalı değil içerikle alakalı //içerikleri baslıga göre getir
        {
            var deger = hm.GetListByWriter(id);
            return View(deger);
        }

        public ActionResult CategoryByHeading(int id) //SOLİD her sınıf kendisine ait işlemleri yapsın  baslıkla alakalı değil içerikle alakalı //içerikleri baslıga göre getir
        {
            var deger = hm.GetListByCategory(id);
            return View(deger);
        }


    }
}