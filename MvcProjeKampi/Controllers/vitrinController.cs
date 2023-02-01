﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class vitrinController : Controller
    {
        // GET: vitrin

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            
            
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var values = cm.GetListById(id);
            return PartialView(values);
        }
    }
}