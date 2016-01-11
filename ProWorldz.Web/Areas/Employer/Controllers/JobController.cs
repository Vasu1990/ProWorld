using ProWorldz.BL.BusinessModel;
using ProWorldz.Web.Areas.Employer.Models;
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
            JobModel Model = new JobModel();
            return View(Model);
        }
        
        public JsonResult PostJob(JobBM Model)
        {
           
            return Json("",JsonRequestBehavior.AllowGet);
        }

    }
}
