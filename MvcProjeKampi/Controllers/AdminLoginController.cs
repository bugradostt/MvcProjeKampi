using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {

        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //Context c = new Context();
            //var values = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            var values = adm.GetByUser(p);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(p.UserName, false);
                Session["AdminUserName"] = p.UserName;
                return RedirectToAction("Index", "AdminHeading");
            }
            else
            {
                ViewBag.Mesaj = "Yanlış veya eksik giriş yaptınız! Lütfen tekrardan deneyiniz.";
                return View();
            }
          
        }




        [HttpGet]
        public ActionResult writerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult writerLogin(Writer p)
        {
            //Context c = new Context();
            //var values = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            var values = wm.GetByWriter(p);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(p.WriterMail, false);
                Session["WriterMail"] = p.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.Mesaj = "Yanlış veya eksik giriş yaptınız! Lütfen tekrardan deneyiniz.";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("writerLogin");
        }

        public ActionResult LogOut2()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}