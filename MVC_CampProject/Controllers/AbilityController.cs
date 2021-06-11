using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CampProject.Controllers
{
    public class AbilityController : Controller
    {
        // GET: Ability
        AbilityManager AbM = new AbilityManager(new EfAbilityDal());
        public ActionResult Index()
        {
            var deger = AbM.GetList();
            return View(deger);
        }
    }
}