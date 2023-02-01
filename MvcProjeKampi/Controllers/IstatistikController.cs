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
    public class IstatistikController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
       
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Istatistik
        public ActionResult Index()
        {
            // toplam kategori
                var categoryCount = cm.GetList().Count();
                ViewBag.categoryCount = categoryCount;
            // end toplam kategori

            //Yazılım Kategorisine Ait Başlık Sayısı
                var categoryYazilimId = cm.GetCategoryName("Yazılım").CategoryId;
                var headingYazilimCount = hm.GetList().Where(x => x.CategoryId == categoryYazilimId).Count();
            ViewBag.headingYazilimCount = headingYazilimCount;
            //End Yazılım Kategorisine Ait Başlık Sayısı

            //En fazla başlığa sahip kategori adı

            

            var headingCategoryIdCount = hm.GetList().GroupBy(x => x.CategoryId).
                 Select(x => new { id = x.Key, toplam = x.Count() }).OrderByDescending(x => x.toplam).First();

            var headingCategoryCount = cm.GetById(headingCategoryIdCount.id).CategoryName;
            
            ViewBag.headingCategoryCount = headingCategoryCount;



                        // var headingCategoryIdCount = hm.GetList().OrderByDescending(x => x.CategoryId).GroupBy(x => x.CategoryId).
                        //    Select(x => new { deger = x.Key, toplma = x.Count() }).First();
                        //var headingCategoryIdCount = hm.GetList().GroupBy(x => x.CategoryId).OrderByDescending(y => y.Key)
                        //var headingCategoryIdCount = hm.GetList().Select(x => new { x.CategoryId }).GroupBy(x => x.CategoryId).OrderByDescending(x => x.Key);
                        //var headingCategoryIdCount = hm.GetList().GroupBy(x => x.CategoryId).
                        //Reverse().Select(z=> new { cate =z.Key , degerId =z}).Count();
                        //var headingCategoryIdCount = hm.GetList().GroupBy(x => x.CategoryId).
                        //OrderByDescending(x=>x.Key).Select(z=> new { cate =z.Key , degerId =z}).Count();
                        //var headingCategoryIdCount = hm.GetList().GroupBy(x => x.CategoryId).Max();
                        //var headingCategoryIdCount = hm.GetList().GroupBy(x => x.CategoryId).Count();

            //end En fazla başlığa sahip kategori adı

            // Yazar Adında 'A' Harfi Geçen Yazar Sayısı
            var writerA = wm.Getlist().Where(x=>x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
                ViewBag.writerA = writerA;
            // end Yazar Adında 'A' Harfi Geçen Yazar Sayısı


            //kategori farkı
                var categoryStatusTrue = cm.GetList().Where(x=>x.CategoryStatus== true).Count();
                ViewBag.categoryStatusTrue = categoryStatusTrue;


                var categoryStatusFalse = cm.GetList().Where(x => x.CategoryStatus == false).Count();
                ViewBag.categoryStatusFalse = categoryStatusFalse;


                var categoryStatusFark = categoryStatusTrue - categoryStatusFalse;
                ViewBag.categoryStatusFark = categoryStatusFark;
            //end kategori farkı

             return View();
        }
    }
}