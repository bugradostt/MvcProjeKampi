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
    public class YetenekKartController : Controller
    {
        YeteneklerManager ym = new YeteneklerManager(new EfYeteneklerDal());
        YetenekHeadingManager yhm = new YetenekHeadingManager(new EfYetenekHeadingDal());

        // GET: YetenekKart
        public ActionResult Index()
        {
            var values = yhm.GetList();
            return View(values);
        }

        public PartialViewResult Yetenekler()
        {
            var values = ym.GetList().OrderByDescending(x => x.YeteneklerId).ToList();
            return PartialView(values);
        }


 
        public PartialViewResult AddYetenekler()
        {
           
            return PartialView();
        }


        [HttpGet]
        public ActionResult AddYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddYetenek(Yetenekler p)
        {
            ym.AddYetenekler(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteYetenek(int id)
        {
            var values = ym.GetById(id);
            ym.DeleteYetenekler(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditYetenek(int id)
        {
            var values = ym.GetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditYetenek(Yetenekler p)
        {
            ym.UpdateYetenekler(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditYetenekHeading(int id)
        {
            var values = yhm.GetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditYetenekHeading(YetenekHeading p)
        {
            yhm.UpdateYetenekHeading(p);
            return RedirectToAction("Index");
        }






    }
}