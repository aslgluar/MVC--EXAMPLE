using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using System.Web.Mvc;

namespace WınUI_PresentationLayer.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());

        
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues );
        }
        [HttpGet]//aynı action isimli ,sayfayı geriye döndür,sayfa yüklenince devreye girer
        public ActionResult AddCategoryBL()
        {
            return View();
        }
        [HttpPost]
        //sayfada bir butona tıklanımca devreye girecek
        //sayfa yüklenirken gereksiz yere veri yüklemesin diye yani aşagıda butona basılınca eklesin diye http post ekledik
        public ActionResult AddCategoryBL(Category p)
        {
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.categoryAddBL(p);

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
        public  ActionResult DeleteCategory(int id)
        {
            var CategoryValue = cm.GetById(id);
            cm.categoryDelete(CategoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.categoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
