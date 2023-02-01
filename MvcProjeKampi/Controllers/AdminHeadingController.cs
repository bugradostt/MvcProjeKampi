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
    public class AdminHeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());


        HeadingValidator hv = new HeadingValidator();

        // GET: AdminHeading
        public ActionResult Index()
        {
            var HeadingValues = hm.GetList().OrderByDescending(x=>x.HeadingStatus).ToList();
            return View(HeadingValues);
        }

        public ActionResult HeadingReport()
        {
            var HeadingValues = hm.GetList().OrderByDescending(x => x.HeadingStatus).ToList();
            return View(HeadingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = i.CategoryName,
                                                  Value = i.CategoryId.ToString()
                                              }).ToList();

            List<SelectListItem> valueWriter = (from i in wm.Getlist()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.WriterName+" "+i.WriterSurname,
                                                      Value = i.WriterId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            ViewBag.valueWriter = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {

            ValidationResult validationResult = hv.Validate(p);
            if (validationResult.IsValid)
            {
                p.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.AddHeading(p);
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
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;

            var valuesId = hm.GetById(id);
            return View(valuesId);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.UpdateHeading(p);
            return RedirectToAction("Index"); 
        }

        public ActionResult DeleteHeading(int id)
        {
          
            var valueId = hm.GetById(id);
            valueId.HeadingStatus = false;
            hm.DeleteHeading(valueId);
            return RedirectToAction("Index");
        }

        public ActionResult AktifHeading(int id)
        {
            var valueId = hm.GetById(id);
            valueId.HeadingStatus = true;
            hm.DeleteHeading(valueId);
            return RedirectToAction("Index");

        }
    }
}