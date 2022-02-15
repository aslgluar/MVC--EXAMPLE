using BussinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BussinessLayer.ValidationRules;

namespace WınUI_PresentationLayer.Controllers
{
    public class _WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager CategoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        WriterValidator validationRules = new WriterValidator();

        Context c = new Context();
        // GET: _WriterPanel

 
        
   

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = writerManager.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {

            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(p);
                return RedirectToAction("AllHeading","_WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult AllHeadings(int p =1)
        {
            var values = headingManager.GetList().ToPagedList(p,4);
            return View(values);
        }
        public ActionResult MyHeadings(string p)
        {
           
            p = (string)Session["WriterMail"];
            var writerİdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerİdInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from category in CategoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.categ_value = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writerİdInfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            p.WriterID = writerİdInfo;
            p.HeadingStatus = true;
            headingManager.HeadingAdd(p);
            return RedirectToAction("MyHeadings");
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
            return RedirectToAction("MyHeadings");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetByID(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("MyHeadings");
        }
    }
}