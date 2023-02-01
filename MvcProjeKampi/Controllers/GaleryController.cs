using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GaleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal()); 

        // GET: Galery
        public ActionResult Index()
        {
            var values = ifm.GetList().OrderByDescending(x=>x.ImageId).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileUrl = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                //string url = "~/Image/" + fileUrl + uzanti;
                string url = "~/Image/" + fileUrl;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.ImagePath = "/Image/" + fileUrl;
                //p.ImagePath = "/Image/" + fileUrl + uzanti;
            }

            ifm.AddImageFile(p);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var ValueId = ifm.GetById(id);
            ifm.DeleteImageFile(ValueId);
            return RedirectToAction("Index");

        }
    }
}