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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category ctgr)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(ctgr);
            if (result.IsValid)
            {
                categoryManager.CategoryAdd(ctgr);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var hata in result.Errors)
                {
                    ModelState.AddModelError(hata.PropertyName, hata.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = categoryManager.GetById(id);
            categoryManager.DeleteCategory(categoryvalue);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateCategoryPage(int id)
        {
            var categoryvalue = categoryManager.GetById(id); // id değişkeninden gelen parametre değerine göre ilgili satırları atama 
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult UpdateCategoryPage(Category c)
        {
            categoryManager.UpdateCategory(c);
            return RedirectToAction("Index");
        }

    }
}