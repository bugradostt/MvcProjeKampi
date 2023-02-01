using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
       // AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public void Index()
        {
            // var values = adm.GetList();
            //return View(values);
            //return RedirectToAction("Index", "AdminUser");
            RedirectToAction("Index", "AdminUSer");
        }
    }
}