using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProWorldz.Web.Areas.Employer.Controllers
{
    public class JobController : Controller
    {
        //
        // GET: /Employer/Job/

        public ActionResult JobPost()
        {
            return View();
        }

    }
}
