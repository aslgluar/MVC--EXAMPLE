using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace WınUI_PresentationLayer.Controllers
{

 
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());//artık ef dal dan interface alacak bagımlılıkları parçalıyoruz
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategoryBL()//aynı action isimli ,sayfayı geriye döndür,sayfa yüklenince devreye girer
        {
            return View();
        }

        [HttpPost]//sayfada bir butona tıklanımca devreye girecek
        public ActionResult AddCategoryBL(Category p)
        //sayfa yüklenirken gereksiz yere veri yüklemesin diye yani aşagıda butona basılınca eklesin diye http post ekledik
        {
            //cm.CategoryAddBL(p);

            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult results = categoryValidatior.Validate(p);
            if (results.IsValid)
            {
                cm.categoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("GetCategoryList");
        }
    }
}