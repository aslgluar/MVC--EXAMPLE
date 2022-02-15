using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        MessageValidator messagevalıdator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox(string p)
        {
            var messagevalues = messageManager.GetListInbox(p);
            return View(messagevalues);
        }

        public ActionResult SendBox(string p)
        {
            var messagevalues = messageManager.GetListSendbox(p);
            return View(messagevalues);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values =messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalıdator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.messageAdd(p);
                return RedirectToAction("SendBox");
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