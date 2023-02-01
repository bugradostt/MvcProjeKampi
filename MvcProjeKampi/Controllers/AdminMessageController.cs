﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());

        MessageValidator mv = new MessageValidator();


        // GET: Message
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];

            var valuesCount = mm.GetListInbox(false,p).Count();
            ViewBag.valuesCount = valuesCount;
            var values = mm.GetListInbox(false,p);
            return View(values);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var values = mm.GetListSendbox(p);
            return View(values);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult GetOkunmamisMessageDetails(int id)
        {
           

            var values = mm.GetById(id);
            GetOkunmamisMessage(values);
            return View(values);
        }

        public void GetOkunmamisMessage(Message p)
        {


            p.Status = false;
            mm.UpdateMessage(p);
            
        }


        public ActionResult GetSendMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        public ActionResult OkunmamisMesaj()
        {
            string p = (string)Session["WriterMail"];

            var valuesCount = mm.GetListInbox(true,p).Count();
            ViewBag.valuesCount = valuesCount;
            var values = mm.GetListInbox(true,p);
            return View(values);
        }



        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string a = (string)Session["WriterMail"];

            ValidationResult validationResult = mv.Validate(p);
            if (validationResult.IsValid)
            {
                p.SenderMail = a;
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.AddMessage(p);
                return RedirectToAction("Sendbox");

            }
            else
            {
                foreach (var i in validationResult.Errors)
                {
                    ModelState.AddModelError(i.PropertyName, i.ErrorMessage);
                }
            }
          

            return View();
        }
    }
}