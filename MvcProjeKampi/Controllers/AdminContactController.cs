using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
       

        ContactValidator cv = new ContactValidator();

        // GET: AdminContact
        public ActionResult Index()
        {
            var values = cm.GetList().OrderByDescending(x=>x.ContactId).ToList();
            return View(values);
        }

        public ActionResult GetContactDetail(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }

        MessageManager mm = new MessageManager(new EfMessageDal());


        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];

            var valuesContactCount = cm.GetList().Count();
            ViewBag.valuesContactCount = valuesContactCount;

            var valuesInboxCount = mm.GetListInbox(false,p).Count();
            ViewBag.valuesInboxCount = valuesInboxCount;

            var valuesOkunmamisCount = mm.GetListInbox(true,p).Count();
            ViewBag.valuesOkunmamisCount = valuesOkunmamisCount;

            var valuesSenboxCount = mm.GetListSendbox(p).Count();
            ViewBag.valuesSenboxCount = valuesSenboxCount;



            return PartialView();
        }
    }
}