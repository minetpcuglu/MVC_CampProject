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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterValidator rules = new WriterValidator();
        WriterManager wm = new WriterManager(new EfWriterDal());

       

        public ActionResult Index()
        {
            var writervalues = wm.GetList();

            return View(writervalues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
           
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)//sonuclar gecerliyse
            {
                wm.writerAdd(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult UpdateWriterPage(int id)
        {
            var deger = wm.GetById(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult UpdateWriterPage(Writer w)
        {
            ValidationResult result = rules.Validate(w);  //kuralların calısması için valıdationrules
            if (result.IsValid)//sonuclar gecerliyse
            {
                wm.writerUpdate(w);
                return RedirectToAction("Index");
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

    }
}