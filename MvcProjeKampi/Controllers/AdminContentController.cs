using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        // GET: AdminContent
        public ActionResult Index(int id)
        {
            var values = cm.GetListById(id);
            return View(values);
        }

       // Context c = new Context();
        public ActionResult GettAllContent(string p="")
        {
            //   var values = from x in c.Contents select x;
            var values = cm.GetList(p);
            /*
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.ContentValue.Contains(p));
            }*/
           // var values =c.Contents.ToList();
            return View(values);
        }
    }
}