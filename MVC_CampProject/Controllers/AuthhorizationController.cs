using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class AuthhorizationController : Controller
    {
        // GET: Authhorization

        AdminManager AdM = new AdminManager(new EfAdminDal());
        AdminRoleManager ArM = new AdminRoleManager(new EfAdminRoleDal());
        AdminValidator rules = new AdminValidator();


        public ActionResult Index()
        {
            var deger = AdM.GetList();
            
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {

            //ilişkili tablolarda ekleme işlemi için viewbag ile veri cekme
            List<SelectListItem> ValueCategory = (from x in ArM.GetRoleList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.RoleName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.RoleId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueCategory;  //tasımak için 
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
          
            //ValidationResult result = rules.Validate(admin);

            //if (result.IsValid)
            //{
                AdM.AdminAdd(admin);
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
        public ActionResult UpdateAdminPage(int id)
        {
            List<SelectListItem> ValueCategory = (from x in ArM.GetRoleList()  //öğeleri listele
                                                  select new SelectListItem //yeni bir liste öğesini sec
                                                  {
                                                      Text = x.RoleName,       //valuenumber = secilen degerin ıd si
                                                      Value = x.RoleId.ToString() //display number ise secilen degerin görüntüsü text olan 
                                                  }).ToList();

            ViewBag.vic = ValueCategory;  //tasımak için 
          
            var adminvalue = AdM.GetById(id); // id değişkeninden gelen parametre değerine göre ilgili satırları atama 
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult UpdateAdminPage(Admin a)
        {
            a.AdminStatus = true;
            AdM.AdminUpdate(a);
            return RedirectToAction("Index");
        }

       public ActionResult DeleteAdmin(int id)
        {
            var deger = AdM.GetById(id);
            deger.AdminStatus = false;
            AdM.AdminDelete(deger);
            return RedirectToAction("Index");

        }



    }
}