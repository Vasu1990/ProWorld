using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using ProWorldz.Web.Areas.Employer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProWorldz.Web.Areas.Employer.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Employer/Account/
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            RegisterModel Model = new RegisterModel();
            Model.Employer = new BL.BusinessModel.EmployerBM();
            Model.SuccessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
          //  Model.ErrorMessage = (TempData[Message.Error] != null ? TempData[Message.Error].ToString() : string.Empty).ToString();
            return View(Model);
        }

     
        public ActionResult SignUp(RegisterModel Model, HttpPostedFileBase file)
        {
            EmployerBL employerBL = new EmployerBL();
            EmployerBM employerBM=new EmployerBM();

            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                if (!Directory.Exists(Server.MapPath("~/Areas/Employer/Content/Logo")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Areas/Employer/Content/Logo"));
                }
                string physicalPath = Server.MapPath("~/Areas/Employer/Content/Logo/" + ImageName);
                file.SaveAs(physicalPath);
                Model.Employer.Path = "~/Areas/Employer/Content/Logo/" + ImageName;
            }
            Model.Employer.CreationDate = DateTime.Now;
            Model.Employer.ModificationDate = DateTime.Now;
            Model.Employer.CreatedBy = 1;
           
            Model.Employer.Password = GenerateRandomAlphaNumericCode(6);
            employerBL.Create(Model.Employer);
            sendMail();
            TempData["Success"] = "Employer Registered Successfully";

            return RedirectToAction("Register");
        }
        public void sendMail()
        {
        }
        public static string GenerateRandomAlphaNumericCode(int length)
        {
            string characterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            //The below code will select the random characters from the set
            //and then the array of these characters are passed to string 
            //constructor to make an alphanumeric string
            string randomCode = new string(
                Enumerable.Repeat(characterSet, length)
                    .Select(set => set[random.Next(set.Length)])
                    .ToArray());
            return randomCode;
        }
    }
}
