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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager MM = new MessageManager(new EfMessageDal());
        MessageValidator rules = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)  //gelen mesajları listeleme
        {
            var deger = MM.GetListInbox(p);
            var count = MM.GetListStatusFalse().Count();
            ViewBag.durum = count;
            
            return View(deger);
        }

        [Authorize]
        public ActionResult SendBox(string p)  //gönderilen mesajlar
        {
            var deger = MM.GetListSendbox(p);
            return View(deger);
        }

        public ActionResult GetInboxMessageDetails(int id) //gelen kutusu detaylarını getir
        {
            var deger = MM.GetById(id);
            deger.Status = true;
            MM.UpdateMessage(deger);
            return View(deger);
        }

        public ActionResult GetSendboxMessageDetails(int id) //gönderilen mesaj detaylarını sayfası
        {
            var deger = MM.GetById(id);
            return View(deger);
        }



       

        [HttpGet]
        public ActionResult AddMessage( )
        {
            return View();
               
        }

        [HttpPost]
        public ActionResult AddMessage(Message p)
        {
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());                 //datetime hatası için 
                MM.MessageAdd(p);
                return RedirectToAction("SendBox");
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