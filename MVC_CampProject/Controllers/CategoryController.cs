
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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal()); //DAL Katmanında EF klasoru olusturuldu


      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var degerler1 = cm.GetList();
            return View(degerler1);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(); //sayfayı geriye döndür
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBl(p);
            CategoryValidator cv = new CategoryValidator(); //kuralların gerçekleşmesi için nesne türettik
            ValidationResult result = cv.Validate(p); //cv den gelen degerlere göre kurallara bak kontrol et
            if (result.IsValid) //sonuc gecerli ise ekleme işlemi gerçekleşir
            {
                cm.CategoryAdd(p); //DAL Katmanında EF klasoru olusturdugumuz cm yi cagırıyoruz 
                return RedirectToAction("GetCategoryList");
            }
            else//sonuc gecersiz ise hatalı ise
            {
                foreach (var hata in result.Errors)
                {
                    ModelState.AddModelError(hata.PropertyName, hata.ErrorMessage);
                }
            }
            return View(); 
        }



    }
}