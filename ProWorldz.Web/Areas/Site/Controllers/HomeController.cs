using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProWorldz.Web.Areas.Site.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Site/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services(string tab)
        {

            ViewBag.TabVal = string.IsNullOrEmpty(tab) ? "Jobs" : tab;
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(ContactUsBM contactBM)
        {
            CommonBL commonBl = new CommonBL();
            contactBM.CreationDate = DateTime.Now;
            int result = commonBl.SubmitContactForm(contactBM);
            return RedirectToAction("ThankYou", new RouteValueDictionary(
              new { controller = "Home", action = "ThankYou", status = result }));
        }

        public ActionResult ThankYou(int status)
        {
            ViewBag.Result = status;
            return View();
        }

    }
}
