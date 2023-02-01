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
    public class AdminUserController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());

        // GET: AdminUser
        public ActionResult Index()
        {

            var values = adm.GetList().OrderByDescending(x => x.AdminId).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var values = adm.GetById(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult EditUser(Admin p)
        {
            adm.UpdateAdmin(p);
            return RedirectToAction("Index");

        }

        public ActionResult AddUser(Admin p)
        {
            adm.AddAdmin(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialAdminUser()
        {
            return PartialView();
        }

        public ActionResult DeleteUser(int id)
        {
            var valuesId = adm.GetById(id);
            adm.DeleteAdmin(valuesId);
            return RedirectToAction("Index");
        }
    }
}