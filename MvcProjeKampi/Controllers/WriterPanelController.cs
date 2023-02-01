using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator wv = new WriterValidator();
        Context c = new Context();

        public ActionResult WriterProfile(int id =0)
        {
            string p = (string)Session["WriterMail"];
            id= c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = wm.GetById(id);
            return View(values);
        }


        [HttpGet]
        public ActionResult EditWriter(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = wm.GetById(id);
            return View(values);
        }


        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult validationResult = wv.Validate(p);
            if (validationResult.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("WriterProfile");

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



        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerInfoId = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writerInfoId);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p )
        {
            string m = (string)Session["WriterMail"];
            var writerInfoId = c.Writers.Where(x => x.WriterMail == m).Select(y => y.WriterId).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writerInfoId;
            p.HeadingStatus = true;
            hm.AddHeading(p);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }


        public ActionResult DeleteHeading(int id)
        {

            var valueId = hm.GetById(id);
            valueId.HeadingStatus = false;
            hm.DeleteHeading(valueId);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p,15);
            return View(headings);
        }
    }
}