using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WınUI_PresentationLayer.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager CategoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager WriterManager = new WriterManager(new EFWriterDAL());


        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //listeleeme yaparken bir liste gönderecek,yani bir ekleme yaptık o eklenen değerin categorisinin
            //listesini getirmek amacımız

            List<SelectListItem> valuecategory = (from category in CategoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categ_value = valuecategory;

            List<SelectListItem> valueWriter = (from writer in WriterManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = writer.WriterName,
                                                    Value = writer.WriterID.ToString()
                                                }).ToList();
            ViewBag.writer_value = valueWriter;

            return View();
        }
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            headingManager.HeadingAdd(p);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> headingvalue = (from category in CategoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.heading_value = headingvalue;

            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}