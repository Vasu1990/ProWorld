using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using ProWorldz.Web.Models;
using ProWorldz.Web.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProWorldz.Web.Controllers
{
    public class LatestTutorialsController : Controller
    {
        //
        // GET: /LatestTechnology/
        LatestTutorialsBL LatestTutorialsBL = new LatestTutorialsBL();

        public ActionResult Index()
        {
            LatestTutorialsModel Model = new LatestTutorialsModel();
            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewTechnology(LatestTutorialsModel Model, HttpPostedFileBase file)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);

            if (CurrentUser != null)
            {
                LatestTutorialsBM LatestTutorialsBM = new LatestTutorialsBM();
                LatestTutorialsBM.CommunityId = Model.LatestTutorialsBM.CommunityId;
                LatestTutorialsBM.SubCommunityId = Model.LatestTutorialsBM.SubCommunityId;
                LatestTutorialsBM.Tag = Model.LatestTutorialsBM.Tag;
                LatestTutorialsBM.Subject = Model.LatestTutorialsBM.Subject;
                LatestTutorialsBM.Topic = Model.LatestTutorialsBM.Topic;
               // LatestTutorialsBM.Content = Model.LatestTutorialsBM.Content;
               // LatestTutorialsBM.Url = Model.LatestTutorialsBM.Url;
                LatestTutorialsBM.VideoUrl = Model.LatestTutorialsBM.VideoUrl;
               // LatestTutorialsBM.FilePath = Model.LatestTutorialsBM.FilePath;
                LatestTutorialsBM.UserId = CurrentUser.Id;
                LatestTutorialsBM.IsActive = true;
                if (file != null)
                {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    if (!Directory.Exists(Server.MapPath("~/Images/TutorialsDocument")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Images/TutorialsDocument"));
                    }
                    string physicalPath = Server.MapPath("~/Images/TutorialsDocument/" + ImageName);
                    file.SaveAs(physicalPath);
                   // LatestTutorialsBM.FilePath = "~/Images/TutorialsDocument/" + ImageName;
                }
                LatestTutorialsBL.Create(LatestTutorialsBM);
                TempData["Success"] = "Record Saved Successfully.";
            }
            else
            {
                TempData["Error"] = "Please Login.";
            }
            return RedirectToAction("Index");
        }

    }
}
