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

namespace MvcProjeKampi.Controllers
{
    public class AdminWriterController : Controller
    {

        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator wv = new WriterValidator();

        // GET: AdminWriter
        public ActionResult Index()
        {
            var writerValues = wm.Getlist();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {

  
            ValidationResult validationResult = wv.Validate(p);
            if (validationResult.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");

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

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var bulunanId = wm.GetById(id);
            return View(bulunanId);
        }


        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult validationResult = wv.Validate(p);
            if (validationResult.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");

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