using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MVC_CampProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator rules = new WriterValidator();
        Context c = new Context();



        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];   //session kullanımı
      
           id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var deger = wm.GetById(id);
            
            return View(deger);

        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {

            ValidationResult result = rules.Validate(p);  //kuralların calısması için valıdationrules
            if (result.IsValid)//sonuclar gecerliyse
            {
                wm.writerUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }


        public ActionResult MyHeading(string p) //baslıklarım 
        {
          
            p = (string)Session["WriterMail"];   //session kullanımı
           var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
          
            var deger = hm.GetListByWriter(writeridinfo);
            return View(deger);
        }

        [HttpGet]
        public ActionResult NewHeading()
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
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"]; //vievbag ile session yapısındaki id ismini tasıyoruz 
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();



            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //tarihi ındex kısmında eklemek istemiyorsak
            p.WriterID = writeridinfo; //oluşturan yazar 
            p.HeadingStatus = true; //baslabgıc değeri
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult HeadingDelete(int id)
        {
            //durumu false true yapmak için
            var deger = hm.GetById(id); //ıd ye göre bul
            deger.HeadingStatus = false;
            hm.HeadingDelete(deger);

            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading( int sayfa =1)
        {

            var deger = hm.GetList().ToPagedList(sayfa,4);
            return View(deger);
        }

     


    }
}