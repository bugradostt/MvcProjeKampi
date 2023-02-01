using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: AdminAbout
        public ActionResult Index()
        {
            var values = abm.GetList().OrderByDescending(x=>x.AboutStatus).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AddAbout(p); 
            return RedirectToAction("Index");

        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult PasifStatus(int id)
        {

            var valueId = abm.GetById(id);
            valueId.AboutStatus= false;
            abm.DeleteAbout(valueId);
            return RedirectToAction("Index");
        }

        public ActionResult AktifStatus(int id)
        {

            var valueId = abm.GetById(id);
            valueId.AboutStatus = true;
            abm.DeleteAbout(valueId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var value = abm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditAbout(About p)
        {
            abm.UpdateAbout(p);
            return RedirectToAction("Index");
        }


    }
}