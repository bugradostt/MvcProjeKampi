﻿using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> cc = new List<CategoryClass>();
            cc.Add(new CategoryClass()
            {
                CategoryName="yazılım",
                CategoryCount=8
            });

            cc.Add(new CategoryClass()
            {
                CategoryName = "Eğitim",
                CategoryCount = 4
            });

            cc.Add(new CategoryClass()
            {
                CategoryName = "yazılım",
                CategoryCount = 8
            });

            cc.Add(new CategoryClass()
            {
                CategoryName = "yazılım",
                CategoryCount = 8
            });

            return cc;
        }
    }
}