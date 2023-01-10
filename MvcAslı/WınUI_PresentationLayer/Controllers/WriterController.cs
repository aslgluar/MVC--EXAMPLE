using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using BussinessLayer.ValidationRules;

using System.Web.Mvc;
using FluentValidation;

namespace WınUI_PresentationLayer.Controllers
{
    [AllowAnonymous]

    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        WriterValidator validationRules = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
           
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                writerManager.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult GetWriterList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetByID(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {

            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(p);
                return RedirectToAction("Index");
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
    }
}