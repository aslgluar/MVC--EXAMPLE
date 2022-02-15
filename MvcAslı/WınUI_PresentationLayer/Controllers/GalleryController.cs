using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WınUI_PresentationLayer.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageManager ımageManager = new ImageManager(new EFImageDAL());
        public ActionResult Index()
        {
            var files = ımageManager.GetList();
            return View(files);
        }
    }
}