using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using ProWorldz.BL.Common.DatatablePaging;
using ProWorldz.BL.Common.Enums;
using ProWorldz.Web.Models;
using ProWorldz.Web.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProWorldz.Web.Controllers
{
    public class HomeController : Controller
    {
        UserPostBL UserPostBL = new UserPostBL();
        UserBL UserBL = new UserBL();
        UserGeneralInformationBL UserGeneralInformationBL = new BL.BusinessLayer.UserGeneralInformationBL();
        UserPersonalInformationBL UserPersonalInformationBL = new BL.BusinessLayer.UserPersonalInformationBL();
        UserProfessionalQualificationBL UserProfessionalQualificationBL = new BL.BusinessLayer.UserProfessionalQualificationBL();
        UserQualificationBL UserQualificationBL = new BL.BusinessLayer.UserQualificationBL();

        public UserBM CurrentUser
        {
            get
            {
                return SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            }
        }


        public ActionResult UserProfile(int Id = 0)
        {
            ViewBag.UserId = Id;
            return View();

        }


        [HttpGet]
        public JsonResult GetUserProfileData(int Id)
        {
            LatestTechnologyBL latestTechnologyBL = new LatestTechnologyBL();
            LatestTutorialsBL latestTutorialsBL = new LatestTutorialsBL();
            UserBM user = UserBL.GetUserById(Id);
            List<UserPostBM> postList = UserPostBL.GetUserPost().Where(a => a.UserId == Id).ToList();
            List<LatestTechnologyBM> lstTechnology = latestTechnologyBL.GetTechnologyByUserId(Id);
            List<LatestTutorialsBM> lstTutorials = latestTutorialsBL.GetTechnologyByUserId(Id);
            UserGeneralInformationBM generalInfo = UserGeneralInformationBL.GetGeneralInformationByUserId(Id);
            UserPersonalInformationBM personalInfo = UserPersonalInformationBL.GetPersonalInformationByUserId(Id);
            List<UserQualificatinBM> userQualificationList = UserQualificationBL.GetUserQualificatinByUserId(Id);
            List<UserProfessionalQualificationBM> userProfessionalList = UserProfessionalQualificationBL.GetProfessionalQualificationByUserId(Id);
            UserProfileModel Model = new UserProfileModel();

            Model.User = user;
            Model.UserPostList = postList;
            Model.LatestTechnologyBMList = lstTechnology;
            Model.LatestTutorialsBMList = lstTutorials;
            Model.UserGeneralInformation = generalInfo;
            Model.UserPersonalInformationBM = personalInfo;
            Model.UserQualificatinBM = userQualificationList;
            Model.UserProfessionalQualificationBM = userProfessionalList;
            return Json(Model);
        }

        UserVideoBL UserVideoBL = new UserVideoBL();

        [HttpGet]
        public ActionResult Index()
        {

            return RedirectToAction("Index", "Home", new { @area = "Site" });
        }

        [Authorize]
        public ActionResult Dashboard(int Id = 0)
        {
            PostCommentModel model = new PostCommentModel();
            UserPostBL blObj = new UserPostBL();
            model.UserPostList = blObj.GetUserPost().OrderByDescending(p => p.CreationDate).Take(10).ToList();
            ViewBag.Id = Id;

            UserBL userBL = new BL.BusinessLayer.UserBL();
            model.User = Id == 0 ? SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User) : userBL.GetUserById(Id);
            model.User.Image = UserGeneralInformationBL.GetGeneralInformationByUserId(model.User.Id) != null ? UserGeneralInformationBL.GetGeneralInformationByUserId(model.User.Id).Image : string.Empty;
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
            commentBM.ModifiedBy = userObj.Id;
            commentBM.ModificationDate = DateTime.UtcNow;

            //date issue http://www.devcurry.com/2013/04/json-dates-are-different-in-aspnet-mvc.html#.Ufvl1Y3VD6Q
            //date issue for ko MVC
            if (commentBM.CreationDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                commentBM.CreationDate = DateTime.Now;
            }


            commentbl.Update(commentBM);
            return Json(commentBM);

        }

        [HttpPost]
        public void DeleteComment(UserPostCommentBM commentBM)
        {
            UserPostCommentCommentBL commentbl = new UserPostCommentCommentBL();

            commentbl.Delete(commentBM);

        }




        [Authorize]
        public ActionResult UserPost()
        {
            PostCommentModel Model = new PostCommentModel();
            Model.UserPostList = UserPostBL.GetUserPost();
            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();
            return View(Model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewPost(PostCommentModel Model, FormCollection collection)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            string type = collection["type"].ToString();
            if (CurrentUser != null)
            {

                UserPostBM UserPostBM = new UserPostBM();
                UserPostBM.Post = Model.UserPost.Post;
                UserPostBM.Subject = Model.UserPost.Subject;
                UserPostBM.UserId = CurrentUser.Id;
                if (!string.IsNullOrEmpty(type))
                    UserPostBM.PostType = Convert.ToInt32(type);
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
            UserGeneralInformationBM UserGeneralInformationBM = new UserGeneralInformationBM();
            if (CurrentUser != null)
                UserGeneralInformationBM = UserGeneralInformationBL.GetGeneralInformationByUserId(CurrentUser.Id);
            return Json(UserGeneralInformationBM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadUserCommunityDetail()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            UserBM userBM = new UserBM();
            if (CurrentUser != null)
                userBM = UserBL.GetUserById(CurrentUser.Id);
            return Json(userBM, JsonRequestBehavior.AllowGet);
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

        [Authorize]
        public ActionResult Friends()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetFriends(GlobalSearchText GlobalSearchText, int RecordsToTake, int RecordsToSkip, List<DataTableConfig> Columns)
        {


            FriendBL frndBL = new FriendBL();
            List<FriendBM> lsFrndBM = new List<FriendBM>();
            DataTableParams param = new DataTableParams();
            param.RecordsToSkip = RecordsToSkip;
            param.RecordsToTake = RecordsToTake;
            param.SearchOptions = GlobalSearchText;
            param.ColumnConfiguration = Columns;
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);

            lsFrndBM = frndBL.GetFriendListById(CurrentUser.Id, param);

            return Json(lsFrndBM);
        }
        public JsonResult GetTotalFriendCount()
        {
            FriendBL frndBL = new FriendBL();
            return Json(frndBL.GetFriendCountById(CurrentUser.Id), JsonRequestBehavior.AllowGet);
        }

        public void AddFriend(FriendBM frnd)
        {
            FriendBL frnbl = new FriendBL();
            List<FriendBM> lsFrndReq = new List<FriendBM>();

            frnd.CreationDate = DateTime.Now;
            frnd.FriendShipStatusId = (int)FriendShipStatus.Pending;
            lsFrndReq.Add(frnd);
            lsFrndReq.Add(GetOtherBM(frnd));

            //cast list to ienumearble call create Friend req
            frnbl.CreateFriendrequest(lsFrndReq);

        }

        public void DeleteFriend(FriendBM frnd)
        {
            FriendBL frnbl = new FriendBL();
            frnbl.DeleteFriend(frnd);

        }

        public FriendBM GetOtherBM(FriendBM frnd)
        {
            FriendBM frndbm = new FriendBM();
            frndbm.CreationDate = frnd.CreationDate;
            frndbm.FriendId = frnd.UserId;
            frndbm.UserId = frnd.FriendId;
            frndbm.FriendShipStatusId = (int)FriendShipStatus.New;
            return frndbm;
        }

        public void RemoveFriend(FriendBM frnd)
        {
            FriendBL frnbl = new FriendBL();
            frnbl.Delete(frnd);
        }

        public void ConfirmRequest(FriendBM frnd)
        {
            FriendBL frnbl = new FriendBL();


            //cast list to ienumearble call create Friend req
            frnbl.ConfirmFriendRequest(frnd);
        }

        public JsonResult GetUserCountByName(string SearchTable)
        {
            string SearchBy = SearchTable == "" ? SessionManager.InstanceCreator.Get<string>("SearchText").ToString() : SearchTable;
            FriendBL frndBL = new FriendBL();
            string _searchtext = SearchBy;

            return Json(frndBL.GetUserCountByName(_searchtext), JsonRequestBehavior.AllowGet);
        }

        public ActionResult People(string SearchText)
        {
            SessionManager.InstanceCreator.Set<string>(SearchText, "SearchText");
            return View();
        }

        [HttpPost]
        public ActionResult People(GlobalSearchText GlobalSearchText, int RecordsToTake, int RecordsToSkip, List<DataTableConfig> Columns)
        {
            List<FriendBM> people = new List<FriendBM>();

            string _searchtext = GlobalSearchText.value != null ? GlobalSearchText.value : SessionManager.InstanceCreator.Get<string>("SearchText").ToString();

            FriendBL frnd = new FriendBL();
            DataTableParams param = new DataTableParams();
            param.RecordsToSkip = RecordsToSkip;
            param.RecordsToTake = RecordsToTake;
            param.SearchOptions = GlobalSearchText;
            param.ColumnConfiguration = Columns;
            people = frnd.GetUsersWithFriendStatus(_searchtext, CurrentUser.Id, param);
            return Json(people);
        }

        [HttpGet]
        public JsonResult GetFriendequests()
        {
            FriendBL frnd = new FriendBL();
            return Json(frnd.GetNewFriends(CurrentUser.Id), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetAllFriends()
        {
            FriendBL frnd = new FriendBL();
            return Json(frnd.GetAllFriends(CurrentUser.Id), JsonRequestBehavior.AllowGet);

        }


        public JsonResult CheckMail(string email)
        {
            UserBM User = UserBL.GetUsers().Where(p => p.Email == email).FirstOrDefault();
            bool IsExist = User != null ? true : false;
            return Json(IsExist, JsonRequestBehavior.AllowGet);

        }


        public JsonResult LoadUserProfileDetail(int Id)
        {
            LatestTechnologyBL latestTechnologyBL = new BL.BusinessLayer.LatestTechnologyBL();
            UserPostBL userPostBL = new BL.BusinessLayer.UserPostBL();
            FriendBL friendBL = new FriendBL();


            LatestTutorialsBL LatestTutorialsBL = new BL.BusinessLayer.LatestTutorialsBL();
            UserProfileModel Model = new UserProfileModel();
            Model.User = UserBL.GetUserById(Id);
            Model.UserGeneralInformation = UserGeneralInformationBL.GetGeneralInformationByUserId(Id);
            Model.UserPersonalInformationBM = UserPersonalInformationBL.GetPersonalInformationByUserId(Id);
            Model.LatestTechnologyBMList = latestTechnologyBL.GetTechnologyByUserId(Id);
            Model.LatestTutorialsBMList = LatestTutorialsBL.GetTechnologyByUserId(Id);
            Model.UserPostList = userPostBL.GetUserPost().Where(a => a.UserId == Id).ToList();
            Model.FriendList = friendBL.GetAllFriends(Id);

            Model.UserProfessionalQualificationBM = UserProfessionalQualificationBL.GetProfessionalQualificationByUserId(Id);

            return Json(Model, JsonRequestBehavior.AllowGet);

        }

        public JsonResult UserBlock(int Id)
        {
            UserBlockBL UserBlockBL = new UserBlockBL();
            UserBlockBM UserBlockBM = new UserBlockBM();
            UserBM userObj = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (userObj != null)
            {
                UserBlockBM = UserBlockBL.GetUserBlockByUserIdAndSharedUserId(userObj.Id, Id);
                if (UserBlockBM == null)
                {
                    UserBlockBM.CurrentUserId = userObj.Id;
                    UserBlockBM.ShareUserId = Id;
                    UserBlockBM.IsBlock = true;
                    UserBlockBM.CreationDate = DateTime.Now;
                    UserBlockBM.CreatedBy = userObj.Id;
                    UserBlockBL.Create(UserBlockBM);
                    return Json("Changes Saved Successfully.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (UserBlockBM.IsBlock)
                        UserBlockBM.IsBlock = false;
                    else
                        UserBlockBM.IsBlock = true;
                    UserBlockBL.Update(UserBlockBM);
                    return Json("Changes Saved Successfully.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Error-Please Login.", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UserFollow(int Id)
        {
            UserBlockBL UserBlockBL = new UserBlockBL();
            UserBlockBM UserBlockBM = new UserBlockBM();
            UserBM userObj = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (userObj != null)
            {
                UserBlockBM = UserBlockBL.GetUserBlockByUserIdAndSharedUserId(userObj.Id, Id);
                if (UserBlockBM == null)
                {
                    UserBlockBM.CurrentUserId = userObj.Id;
                    UserBlockBM.ShareUserId = Id;
                    UserBlockBM.IsFollow = true;
                    UserBlockBM.CreationDate = DateTime.Now;
                    UserBlockBM.CreatedBy = userObj.Id;
                    UserBlockBL.Create(UserBlockBM);
                    return Json("Changes Saved Successfully.", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (UserBlockBM.IsFollow)
                        UserBlockBM.IsFollow = false;
                    else
                        UserBlockBM.IsFollow = true;
                    UserBlockBL.Update(UserBlockBM);
                    return Json("Changes Saved Successfully.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Error-Please Login.", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ShareContactDetail(int Id, string Message)
        {
            ShareContactDetailBL shareContactDetailBL = new ShareContactDetailBL();
            ShareContactDetailBM shareContactDetailBM = new ShareContactDetailBM();
            UserBM userObj = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (userObj != null)
            {
                shareContactDetailBM.CurrentUserId = userObj.Id;
                shareContactDetailBM.ShareUserId = Id;
                shareContactDetailBM.Message = Message;
                shareContactDetailBM.CreatedBy = userObj.Id;
                shareContactDetailBM.CreationDate = DateTime.Now;
                shareContactDetailBL.Create(shareContactDetailBM);
                return Json("Changes Saved Successfully.", JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json("Error-Please Login.", JsonRequestBehavior.AllowGet);
            }

        }

    }
}
