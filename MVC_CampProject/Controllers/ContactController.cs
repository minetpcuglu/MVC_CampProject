using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
   
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator rules = new ContactValidator();
        // GET: Contact

       
        public ActionResult Index()
        {
            var contactRules = cm.GetList();
            
            return View(contactRules);
        }
      



        public ActionResult GetContactDetails(int id) //iletişimin detaylarını getir
        {
            var deger = cm.GetById(id);
            return View(deger);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}