using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using ProWorldz.BL.Enum;
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
    public class LatestTechnologyController : Controller
    {
        //
        // GET: /LatestTechnology/
        LatestTechnologyBL latestTechnologyBL = new LatestTechnologyBL();

        public ActionResult Index()
        {
            LatestTechnologyModel Model = new LatestTechnologyModel();
            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewTechnology(LatestTechnologyModel Model, FormCollection collection, List<HttpPostedFileBase> file)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);

            if (CurrentUser != null)
            {
                string url = collection["url"].ToString();
                string[] strUrlArray = new string[] { };
                if (!string.IsNullOrEmpty(url))
                    strUrlArray = url.Split(',');
                //  string filepaths = collection["file"].ToString();
                LatestTechnologyBM latestTechnologyBM = new LatestTechnologyBM();
                latestTechnologyBM.CommunityId = Model.latestTechnologyBM.CommunityId;
                latestTechnologyBM.SubCommunityId = Model.latestTechnologyBM.SubCommunityId;
                latestTechnologyBM.Tag = Model.latestTechnologyBM.Tag;
                latestTechnologyBM.Subject = Model.latestTechnologyBM.Subject;
                latestTechnologyBM.Topic = Model.latestTechnologyBM.Topic;
                // latestTechnologyBM.Content = Model.latestTechnologyBM.Content;
                // latestTechnologyBM.Url = Model.latestTechnologyBM.Url;
                //latestTechnologyBM.VideoUrl = Model.latestTechnologyBM.VideoUrl;
                // latestTechnologyBM.FilePath = Model.latestTechnologyBM.FilePath;
                latestTechnologyBM.UserId = CurrentUser.Id;
                latestTechnologyBM.IsActive = true;

             
             int Id=   latestTechnologyBL.Create(latestTechnologyBM);

             #region MultipleUrl
             foreach (var strUrl in strUrlArray)
             {
                 MasterUrlBL masterUrlBL = new MasterUrlBL();
                 MasterUrlBM masterUrlBM = new MasterUrlBM();
                 masterUrlBM.ModuleId = Id;
                 masterUrlBM.Url = strUrl;
                 masterUrlBL.Create(masterUrlBM);
             }
             #endregion
             #region MultipleFile
             foreach (var fileInstance in file)
             {
                 if (fileInstance != null)
                 {
                     string ImageName = System.IO.Path.GetFileName(fileInstance.FileName);
                     if (!Directory.Exists(Server.MapPath("~/Images/TechnologyDocument")))
                     {
                         Directory.CreateDirectory(Server.MapPath("~/Images/TechnologyDocument"));
                     }
                     string physicalPath = Server.MapPath("~/Images/TechnologyDocument/" + ImageName);
                     fileInstance.SaveAs(physicalPath);
                     //     latestTechnologyBM.FilePath = "~/Images/TechnologyDocument/" + ImageName;

                     MasterFilePathBL masterFilePathBL = new MasterFilePathBL();
                     MasterFilePathBM masterFilePathBM = new MasterFilePathBM();
                     masterFilePathBM.ModuleId = Id;
                     masterFilePathBM.FilePath = "~/Images/TechnologyDocument/" + ImageName; ;
                     masterFilePathBL.Create(masterFilePathBM);
                 }
             }
             #endregion
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
