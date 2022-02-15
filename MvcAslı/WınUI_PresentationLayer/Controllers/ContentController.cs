using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WınUI_PresentationLayer.Controllers
{
    public class ContentController : Controller
    {

        ContentManager cm = new ContentManager(new EFContentDAL());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValue = cm.GetListByHeadingID(id);
            return View(contentValue);
        }
    }
}