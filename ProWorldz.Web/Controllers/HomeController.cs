using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using ProWorldz.Web.Models;
using ProWorldz.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProWorldz.Web.Controllers
{
    public class HomeController : Controller
    {
        UserPostBL UserPostBL = new UserPostBL();

        UserGeneralInformationBL UserGeneralInformationBL = new BL.BusinessLayer.UserGeneralInformationBL();
        UserPersonalInformationBL UserPersonalInformationBL = new BL.BusinessLayer.UserPersonalInformationBL();
        UserProfessionalQualificationBL UserProfessionalQualificationBL = new BL.BusinessLayer.UserProfessionalQualificationBL();
        UserQualificationBL UserQualificationBL = new BL.BusinessLayer.UserQualificationBL();

        UserVideoBL UserVideoBL = new UserVideoBL();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            UserBL userBL = new UserBL();

            return RedirectToAction("Login", "Account");
        }
            
        [Authorize]
        public ActionResult Dashboard()
        {
            PostCommentModel model = new PostCommentModel();
            UserPostBL blObj = new UserPostBL();
            model.UserPostList = blObj.GetUserPost();
            
            model.User  = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            return View(model);

        }
        [HttpPost]
        public JsonResult PostComment(UserPostCommentBM commentBM)
        {
            UserPostCommentCommentBL commentbl = new UserPostCommentCommentBL();
            UserBM userObj = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            commentBM.UserName = userObj.Name;
            commentBM.UserId = userObj.Id;
            commentBM.CreatedBy = userObj.Id;
            commentBM.CreationDate = DateTime.Now;
            

            int CommentId = commentbl.Create(commentBM);
            commentBM.Id = CommentId;
            return Json(commentBM);
        }

        
        [HttpPost]
        public JsonResult EditComment(UserPostCommentBM commentBM)
        {
            UserPostCommentCommentBL commentbl = new UserPostCommentCommentBL();
            UserBM userObj = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            commentBM.ModifiedBy= userObj.Id;
            commentBM.ModificationDate = DateTime.Now;


            commentbl.Update(commentBM);
            return Json(commentBM);

        }

        [HttpPost]
        public void DeleteComment(UserPostCommentBM commentBM)
        {
            UserPostCommentCommentBL commentbl = new UserPostCommentCommentBL();
            
            commentbl.Delete(commentBM);

        }





        public ActionResult UserPost()
        {
            PostCommentModel Model = new PostCommentModel();
            Model.UserPostList = UserPostBL.GetUserPost();
            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();
            return View(Model);
        }

        public ActionResult ViewProfile()
        {
            ViewProfileModel Model = new ViewProfileModel();
           
            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();
            return View(Model);
        }
        [ValidateInput(false)]
        public ActionResult PostComment(PostCommentModel Model)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
           // UserBM CurrentUser = (UserBM)Session["User"];
            if (CurrentUser != null)
            {

                UserPostBM UserPostBM = new UserPostBM();
                UserPostBM.Post = Model.UserPost.Post;
                UserPostBM.Subject = Model.UserPost.Subject;
                UserPostBM.UserId = CurrentUser.Id;
                UserPostBM.CreatedBy = CurrentUser.Id;
                UserPostBM.CreationDate = DateTime.Now;
                UserPostBL.Create(UserPostBM);
                TempData["Success"] = "Record saved Successfully.";
            }
            else
            {
                TempData["Error"] = "Please Login.";
            }
            return RedirectToAction("UserPost");
        }
        public JsonResult GetUserGeneralDetail()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            UserGeneralInformationBM UserGeneralInformationBM=new UserGeneralInformationBM();
            if (CurrentUser != null)
                UserGeneralInformationBM = UserGeneralInformationBL.GetGeneralInformationByUserId(CurrentUser.Id);
            return Json(UserGeneralInformationBM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadUserPersonalDetail()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            UserPersonalInformationBM UserPersonalInformationBM = new UserPersonalInformationBM();
            if (CurrentUser != null)
                UserPersonalInformationBM = UserPersonalInformationBL.GetPersonalInformationByUserId(CurrentUser.Id);
            return Json(UserPersonalInformationBM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadUserProfessionalDetail()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            List<UserProfessionalQualificationBM> UserProfessionalQualificationList = new List<UserProfessionalQualificationBM>();
            if (CurrentUser != null)
                UserProfessionalQualificationList = UserProfessionalQualificationBL.GetProfessionalQualificationByUserId(CurrentUser.Id);
            return Json(UserProfessionalQualificationList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserQualificationalDetail()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            List<UserQualificatinBM> UserQualificatinBM = new List<UserQualificatinBM>();
            if (CurrentUser != null)
                UserQualificatinBM = UserQualificationBL.GetUserQualificatinByUserId(CurrentUser.Id);
            return Json(UserQualificatinBM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadUserVideoDetail()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            UserVideoBM UserVideoBM = new UserVideoBM();
            if (CurrentUser != null)
                UserVideoBM = UserVideoBL.GetByUserId(CurrentUser.Id);
            return Json(UserVideoBM, JsonRequestBehavior.AllowGet);
        }

    }
}
