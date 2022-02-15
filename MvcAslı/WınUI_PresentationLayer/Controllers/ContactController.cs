using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WınUI_PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EFContactDAL());

        ContactValidator validationRules = new ContactValidator();


        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu ()
        {
            
            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = contactManager.GetById(id);
            return View(contactvalue);
        }


    }
}