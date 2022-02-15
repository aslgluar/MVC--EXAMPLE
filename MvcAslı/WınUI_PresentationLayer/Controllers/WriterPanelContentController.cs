using BussinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;

namespace WınUI_PresentationLayer.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDAL());
        Context c = new Context();
        // GET: WriterPanelContent

        public ActionResult MyContent(string p)
        {
           
           // int id = 4;
            p = (string)Session["WriterMail"];
            //ViewBag.d = p;
            var WriteridInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValue = cm.GetListByWriter(WriteridInfo);
            return View(contentValue);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string Mail = (string)Session["WriterMail"];
            var WriteridInfo = c.Writers.Where(x => x.WriterMail == Mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}