using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WınUI_PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());

        ContentManager cm = new ContentManager(new EFContentDAL());
        // GET: Default
        public PartialViewResult Index(int id =0)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return PartialView(contentvalues);
        }

        public ActionResult Headings()
        {
            var values = headingManager.GetList();
            return View(values);
        }
    }
}