using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ProWorldz.Web.Filters;
using ProWorldz.Web.Models;
using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using ProWorldz.Web.Utils;
using System.Net.Mail;
using System.Net;

namespace ProWorldz.Web.Controllers
{

    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        UserGeneralInformationBL UserGeneralInformationBL = new BL.BusinessLayer.UserGeneralInformationBL();
        UserPersonalInformationBL UserPersonalInformationBL = new BL.BusinessLayer.UserPersonalInformationBL();
        UserProfessionalQualificationBL UserProfessionalQualificationBL = new BL.BusinessLayer.UserProfessionalQualificationBL();
        UserQualificationBL UserQualificationBL = new BL.BusinessLayer.UserQualificationBL();

        UserVideoBL UserVideoBL = new UserVideoBL();
        public ActionResult Test()
        {

            UserModel Model = new UserModel();

            //    List<string> mylist = new List<string>({Id= "element1",Name= "element2" });
            CommunityBL CommunityBL = new BL.BusinessLayer.CommunityBL();

            Model.CommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId == 0).ToList();

            Model.SubCommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId != 0).ToList();
            return View(Model);
        }
        public ActionResult Login(string returnUrl)
        {
            LoginModel Model = new LoginModel();
            Model.SucessMessage = (TempData[Message.Success] != null ? TempData[Message.Success].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData[Message.Error] != null ? TempData[Message.Error].ToString() : string.Empty).ToString();

            return View(Model);
        }
        public ActionResult Resume()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(LoginModel Model)
        {
            if (ModelState.IsValid)
            {
                UserBL UserBL = new BL.BusinessLayer.UserBL();
                UserBM User = UserBL.GetUsers().Where(p => p.Email == Model.Email && p.Password == Model.Password).FirstOrDefault();
                if (User != null)
                {
                    User.IsOnline = true;
                    UserBL.UpdateUser(User);
                    User.Image = UserGeneralInformationBL.GetGeneralInformationByUserId(User.Id) != null ? UserGeneralInformationBL.GetGeneralInformationByUserId(User.Id).Image : string.Empty;
                    SessionManager.InstanceCreator.Set<UserBM>(User, SessionKey.User);
                    //  Session["User"] = User;
                    FormsAuthentication.SetAuthCookie(User.Name, false);
                    return RedirectToAction("DashBoard", "Home");
                }
                else
                {
                    TempData["Error"] = "Invalid username and password";
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Login");
        }
        public new ActionResult Profile()
        {
            ViewProfileModel Model = new ViewProfileModel();

            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();
            return View(Model);
        }
        public ActionResult EditProfile()
        {
            CommonBL commonBL = new CommonBL();
            CommunityBL CommunityBL = new BL.BusinessLayer.CommunityBL();
            CountryBL CountryBL = new BL.BusinessLayer.CountryBL();
            StateBL StateBL = new BL.BusinessLayer.StateBL();
            CityBL CityBL = new BL.BusinessLayer.CityBL();
            ProfileModel Model = new ProfileModel();

            List<IndustryBM> IndustryList = commonBL.GetIndustry();
            Model.SucessMessage = (TempData["Success"] != null ? TempData["Success"].ToString() : string.Empty).ToString();
            Model.ErrorMessage = (TempData["Error"] != null ? TempData["Error"].ToString() : string.Empty).ToString();

            if (SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User) != null)
            {

                UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
                Model.UserBM = CurrentUser;
                ViewBag.CurrentUser = CurrentUser.Name;
                List<UserGeneralInformationBM> GenerealInfoList = UserGeneralInformationBL.GetGeneralInformation().Where(p => p.UserId == CurrentUser.Id).ToList();
                if (GenerealInfoList.Count > 0)
                    Model.UserGeneralInformationModel = GenerealInfoList.FirstOrDefault();
                if (Model.UserGeneralInformationModel == null)
                    Model.UserGeneralInformationModel = new UserGeneralInformationBM();

                List<UserVideoBM> UserVideoList = UserVideoBL.GetUserVideo().Where(p => p.UserId == CurrentUser.Id).ToList();
                if (UserVideoList.Count > 0)
                    Model.UserVideoModel = UserVideoList.FirstOrDefault();
                if (Model.UserVideoModel == null)
                    Model.UserVideoModel = new UserVideoBM();

                //List<UserPersonalInformationBM> PersoalInfoList = UserPersonalInformationBL.GetPersonalInformation().Where(p => p.UserId == CurrentUser.Id).ToList();
                //if (PersoalInfoList.Count > 0)
                //    Model.UserPersonalInformationModel = PersoalInfoList.FirstOrDefault();
                //if (Model.UserPersonalInformationModel == null)
                //    Model.UserPersonalInformationModel = new UserPersonalInformationBM();

                Model.CommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId == 0).ToList();

                Model.SubCommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId != 0).ToList();
                Model.CountryList = CountryBL.GetCountry();
                Model.StateList = StateBL.GetState();
                Model.CityList = CityBL.GetCities();

                return View(Model);
            }
            return RedirectToAction("Login");
        }



        [HttpPost]
        public ActionResult ForgotPassword(LoginModel Model)
        {
            TempData["Success"] = "Password Has been send on your emal.";
            return RedirectToAction("Login");
        }

        public ActionResult UpdateGeneralInformation(ProfileModel Model, HttpPostedFileBase file, FormCollection collection)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (CurrentUser != null)
            {
                if (Model.UserGeneralInformationModel.Id == 0)
                {
                    if (file != null)
                    {
                        UserGeneralInformationBL UserGeneralInformationBL = new BL.BusinessLayer.UserGeneralInformationBL();

                        string ImageName = System.IO.Path.GetFileName(file.FileName);
                        string physicalPath = Server.MapPath("~/Images/" + ImageName);
                        file.SaveAs(physicalPath);
                        UserGeneralInformationBM UserGeneralInformation = new UserGeneralInformationBM();

                        UserGeneralInformation.Image = "/Images/" + ImageName;

                        UserGeneralInformation.PhoneNumber = Model.UserGeneralInformationModel.PhoneNumber;
                        UserGeneralInformation.Address1 = Model.UserGeneralInformationModel.Address1;
                        UserGeneralInformation.Address2 = Model.UserGeneralInformationModel.Address2;
                        UserGeneralInformation.FatherName = Model.UserGeneralInformationModel.FatherName;
                        UserGeneralInformation.Status = Model.UserGeneralInformationModel.Status;
                        UserGeneralInformation.UserId = CurrentUser.Id;
                        UserGeneralInformation.CreatedBy = CurrentUser.Id;
                        UserGeneralInformation.CreationDate = DateTime.Now;
                        UserGeneralInformationBL.Create(UserGeneralInformation);
                        TempData["Success"] = "Record saved Successfully.";


                    }
                }
                else
                {
                    //update code
                    UserGeneralInformationBM UserGeneralInformationBM = UserGeneralInformationBL.GetGeneralInformationByUserId(CurrentUser.Id);
                    UserGeneralInformationBM.CommunityId = Model.UserGeneralInformationModel.CommunityId;
                    UserGeneralInformationBM.SubCommunityId = Model.UserGeneralInformationModel.SubCommunityId;
                    // UserGeneralInformationBM.Image = "/Images/" + ImageName;
                    if (file != null)
                    {

                        string ImageName = System.IO.Path.GetFileName(file.FileName);
                        string physicalPath = Server.MapPath("~/Images/" + ImageName);
                        file.SaveAs(physicalPath);
                        UserGeneralInformationBM.Image = "/Images/" + ImageName;
                    }
                    UserGeneralInformationBM.PhoneNumber = Model.UserGeneralInformationModel.PhoneNumber;
                    UserGeneralInformationBM.Address1 = Model.UserGeneralInformationModel.Address1;
                    UserGeneralInformationBM.Address2 = Model.UserGeneralInformationModel.Address2;
                    UserGeneralInformationBM.FatherName = Model.UserGeneralInformationModel.FatherName;
                    UserGeneralInformationBM.Status = Model.UserGeneralInformationModel.Status;
                    UserGeneralInformationBM.UserId = CurrentUser.Id;
                    UserGeneralInformationBM.ModifiedBy = CurrentUser.Id;
                    UserGeneralInformationBM.ModificationDate = DateTime.Now;
                    UserGeneralInformationBL.Update(UserGeneralInformationBM);


                }
            }
            else
            {
                TempData["Error"] = "Please Login.";
            }

            return RedirectToAction("Profile");
        }



        public ActionResult UpdatePersonalInformation(ProfileModel Model, FormCollection collection)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (CurrentUser != null)
            {
                string test = collection["hdCommunityName"].ToString();
                string test2 = collection["hdSubCommunityName"].ToString();
                UserBL UserBL = new UserBL();
                CurrentUser.CountryId = Model.UserBM.CountryId;
                CurrentUser.StateId = Model.UserBM.StateId;
                CurrentUser.CityId = Model.UserBM.CityId;
                CurrentUser.CommunityId = Model.UserBM.CommunityId;
                CurrentUser.SubCommunityId = Model.UserBM.SubCommunityId;
                if (!string.IsNullOrEmpty(collection["hdCommunityName"].ToString()))
                    CurrentUser.CommunityName = collection["hdCommunityName"].ToString();
                if (!string.IsNullOrEmpty(collection["hdSubCommunityName"].ToString()))
                    CurrentUser.SubCommunityName = collection["hdSubCommunityName"].ToString();

                UserBL.UpdateUser(CurrentUser);
                SessionManager.InstanceCreator.Set<UserBM>(CurrentUser, SessionKey.User);
                TempData["Success"] = "Record saved Successfully.";

            }
            else
            {
                TempData["Error"] = "Please Login.";
            }

            return RedirectToAction("Profile");
        }

        public ActionResult UserVideo(ProfileModel Model)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (CurrentUser != null)
            {
                if (Model.UserVideoModel.Id == 0)
                {

                    UserVideoBM UserVideoBM = new UserVideoBM();
                    UserVideoBM.VideoResumeUrl = Model.UserVideoModel.VideoResumeUrl;
                    UserVideoBM.ArtWorkYouTube1 = Model.UserVideoModel.ArtWorkYouTube1;
                    UserVideoBM.ArtWorkYouTube2 = Model.UserVideoModel.ArtWorkYouTube2;
                    UserVideoBM.ArtWorkYouTube3 = Model.UserVideoModel.ArtWorkYouTube3;
                    UserVideoBM.ArtWorkYouTube4 = Model.UserVideoModel.ArtWorkYouTube4;
                    UserVideoBM.ArtWorkYouTube5 = Model.UserVideoModel.ArtWorkYouTube5;
                    UserVideoBM.ArtWorkUrl1 = Model.UserVideoModel.ArtWorkUrl1;
                    UserVideoBM.ArtWorkUrl2 = Model.UserVideoModel.ArtWorkUrl2;
                    UserVideoBM.ArtWorkUrl3 = Model.UserVideoModel.ArtWorkUrl3;

                    UserVideoBM.UserId = CurrentUser.Id;
                    UserVideoBM.CreatedBy = CurrentUser.Id;
                    UserVideoBM.CreationDate = DateTime.Now;
                    UserVideoBL.Create(UserVideoBM);
                    TempData["Success"] = "Record saved Successfully.";
                }
                else
                {
                    UserVideoBM UserVideoBM = UserVideoBL.GetUserVideo().Where(p => p.UserId == CurrentUser.Id).FirstOrDefault();

                    UserVideoBM.VideoResumeUrl = Model.UserVideoModel.VideoResumeUrl;
                    UserVideoBM.ArtWorkYouTube1 = Model.UserVideoModel.ArtWorkYouTube1;
                    UserVideoBM.ArtWorkYouTube2 = Model.UserVideoModel.ArtWorkYouTube2;
                    UserVideoBM.ArtWorkYouTube3 = Model.UserVideoModel.ArtWorkYouTube3;
                    UserVideoBM.ArtWorkYouTube4 = Model.UserVideoModel.ArtWorkYouTube4;
                    UserVideoBM.ArtWorkYouTube5 = Model.UserVideoModel.ArtWorkYouTube5;
                    UserVideoBM.ArtWorkUrl1 = Model.UserVideoModel.ArtWorkUrl1;
                    UserVideoBM.ArtWorkUrl2 = Model.UserVideoModel.ArtWorkUrl2;
                    UserVideoBM.ArtWorkUrl3 = Model.UserVideoModel.ArtWorkUrl3;

                    UserVideoBM.UserId = CurrentUser.Id;
                    UserVideoBM.CreatedBy = CurrentUser.Id;
                    UserVideoBM.CreationDate = DateTime.Now;
                    UserVideoBM.ModifiedBy = CurrentUser.Id;
                    UserVideoBM.ModificationDate = DateTime.Now;
                    UserVideoBL.Update(UserVideoBM);
                }

            }
            else
            {
                TempData["Error"] = "Please Login.";
            }

            return RedirectToAction("Profile");
        }
        public ActionResult UserProfessionalQualification(ProfileModel Model, FormCollection collection)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (CurrentUser != null)
            {

                UserProfessionalQualificationBM UserProfessionalQualificationBM = new UserProfessionalQualificationBM();
                if (Model.UserProfessionalQualificationModel.Id == 0)
                {
                    UserProfessionalQualificationBM.CompanyName = Model.UserProfessionalQualificationModel.CompanyName;
                    UserProfessionalQualificationBM.StartDate = Model.UserProfessionalQualificationModel.StartDate;
                    UserProfessionalQualificationBM.EndDate = Model.UserProfessionalQualificationModel.EndDate;
                    UserProfessionalQualificationBM.Designation = Convert.ToInt32(collection["DesignationType"].ToString());//Note remove DS
                    UserProfessionalQualificationBM.Salary = Model.UserProfessionalQualificationModel.Salary;
                    UserProfessionalQualificationBM.UserRole = Model.UserProfessionalQualificationModel.UserRole;
                    UserProfessionalQualificationBM.Skill = Model.UserProfessionalQualificationModel.Skill;
                    UserProfessionalQualificationBM.IndustryTypeId = Model.UserProfessionalQualificationModel.IndustryTypeId;
                    UserProfessionalQualificationBM.UserId = CurrentUser.Id;
                    UserProfessionalQualificationBM.CreatedBy = CurrentUser.Id;
                    UserProfessionalQualificationBM.CreationDate = DateTime.Now;

                    UserProfessionalQualificationBL.Create(UserProfessionalQualificationBM);
                    TempData["Success"] = "Record saved Successfully.";
                }
                else
                {
                    UserProfessionalQualificationBM = UserProfessionalQualificationBL.GetProfessionalQualificationById(Model.UserProfessionalQualificationModel.Id);
                    UserProfessionalQualificationBM.CompanyName = Model.UserProfessionalQualificationModel.CompanyName;
                    UserProfessionalQualificationBM.StartDate = Model.UserProfessionalQualificationModel.StartDate;
                    UserProfessionalQualificationBM.EndDate = Model.UserProfessionalQualificationModel.EndDate;
                    UserProfessionalQualificationBM.Designation = Convert.ToInt32(collection["DesignationType"].ToString());//Note remove DS
                    UserProfessionalQualificationBM.Salary = Model.UserProfessionalQualificationModel.Salary;
                    UserProfessionalQualificationBM.UserRole = Model.UserProfessionalQualificationModel.UserRole;
                    UserProfessionalQualificationBM.Skill = Model.UserProfessionalQualificationModel.Skill;
                    UserProfessionalQualificationBM.IndustryTypeId = Model.UserProfessionalQualificationModel.IndustryTypeId;
                    UserProfessionalQualificationBM.UserId = CurrentUser.Id;
                    UserProfessionalQualificationBM.CreatedBy = CurrentUser.Id;
                    UserProfessionalQualificationBM.CreationDate = DateTime.Now;

                    UserProfessionalQualificationBL.Update(UserProfessionalQualificationBM);
                    TempData["Success"] = "Record saved Successfully.";
                }

            }
            else
            {
                TempData["Error"] = "Please Login.";
            }

            return RedirectToAction("Profile");
        }

        public JsonResult GetProfessionalData()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            List<UserProfessionalQualificationBM> UserProfessionalQualificationBMList = new List<UserProfessionalQualificationBM>();
            if (CurrentUser != null)
            {
                UserProfessionalQualificationBMList = UserProfessionalQualificationBL.GetProfessionalQualification().Where(a => a.UserId == CurrentUser.Id).ToList();

            }
            else
            {

                UserProfessionalQualificationBMList = null;

            }
            return Json(UserProfessionalQualificationBMList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetQualificationData()
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            List<UserQualificatinBM> UserQualificatinList = new List<UserQualificatinBM>();
            if (CurrentUser != null)
            {
                UserQualificatinList = UserQualificationBL.GetUserQualificatin().Where(a => a.UserId == CurrentUser.Id).ToList();

            }
            else
            {

                UserQualificatinList = null;

            }
            return Json(UserQualificatinList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserQualification(ProfileModel Model)
        {
            UserBM CurrentUser = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (CurrentUser != null)
            {

                UserQualificatinBM UserQualificatinBM = new UserQualificatinBM();
                UserQualificatinBM.SchoolName = Model.UserQualificatinModel.SchoolName;
                UserQualificatinBM.Degree = Model.UserQualificatinModel.Degree;
                UserQualificatinBM.Percentage = Model.UserQualificatinModel.Percentage;
                UserQualificatinBM.Description = Model.UserQualificatinModel.Description;
                UserQualificatinBM.StartDate = Model.UserQualificatinModel.StartDate;
                UserQualificatinBM.EndDate = Model.UserQualificatinModel.EndDate;

                UserQualificatinBM.UserId = CurrentUser.Id;
                UserQualificatinBM.CreatedBy = CurrentUser.Id;
                UserQualificatinBM.CreationDate = DateTime.Now;
                UserQualificationBL.Create(UserQualificatinBM);
                TempData["Success"] = "Record saved Successfully.";

            }
            else
            {
                TempData["Error"] = "Please Login.";
            }

            return RedirectToAction("Profile");
        }


        public ActionResult LogOff()
        {
            UserBM User = SessionManager.InstanceCreator.Get<UserBM>(SessionKey.User);
            if (User != null)
            {
                User.IsOnline = false;
                UserBL userBL = new UserBL();
                userBL.UpdateUser(User);
            }
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {

            UserModel Model = new UserModel();

            //    List<string> mylist = new List<string>({Id= "element1",Name= "element2" });
            CommunityBL CommunityBL = new BL.BusinessLayer.CommunityBL();

            Model.CommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId == 0).ToList();

            Model.SubCommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId != 0).ToList();
            return View(Model);
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Signup(UserModel model, FormCollection collection)
        {

            UserBL userBL = new UserBL();
            UserBM userBM = new UserBM();
            userBM.Name = model.Name;
            userBM.Email = model.Email;
            userBM.Password = model.Password;
            userBM.UserTypeId = Convert.ToInt32(collection["UserType"].ToString());
            userBM.DOB = Convert.ToDateTime(model.DOB);

            userBM.Gender = collection["gender"].ToString();

            userBM.Active = true;
            userBM.CommunityId = model.CommunityId;
            userBM.SubCommunityId = model.SubCommunityId;
            userBM.CountryId = model.CountryId;
            userBM.StateId = model.StateId;
            userBM.CityId = model.CityId;
            userBM.CommunityName = collection["hdCommunityName"].ToString();
            userBM.SubCommunityName = collection["hdSubCommunityName"].ToString();
            userBM.CreatedBy = 1;
            userBM.ModifiedBy = 1;

            userBM.CreationDate = DateTime.Now.Date;
            userBM.ModificationDate = DateTime.Now.Date;

            int userId = userBL.Create(userBM);

            FillUserGeneralInformation(userId);
            TempData[Message.Success] = "User Registered Successfully. Please Login.";
            // If we got this far, something failed, redisplay form
            return RedirectToAction("Login");
        }

        public void FillUserGeneralInformation(int UserId)
        {

            UserGeneralInformationBM UserGeneralInformation = new UserGeneralInformationBM();

            UserGeneralInformation.Image = "/Images/" + "No-Image.jpg";
            UserGeneralInformation.UserId = UserId;
            UserGeneralInformation.CreatedBy = UserId;
            UserGeneralInformation.CreationDate = DateTime.Now;
            UserGeneralInformationBL.Create(UserGeneralInformation);

        }

        public JsonResult GetCommunityByCountry(int Id)
        {
            List<CommunityBM> communityList = new List<CommunityBM>();
            CommunityBL communityBL = new CommunityBL();
            communityList = communityBL.GetCommunityByCountryId(Id);
            return Json(communityList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStateByCountry(int Id)
        {
            List<StateBM> stateList = new List<StateBM>();
            StateBL stateBL = new StateBL();
            stateList = stateBL.GetStateByCountry(Id);
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetCityByState(int Id)
        {
            List<CityBM> cityList = new List<CityBM>();
            CityBL cityBL = new CityBL();
            cityList = cityBL.GetCityByState(Id);
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSubCommunityByCommunity(int Id)
        {
            List<CommunityBM> communityList = new List<CommunityBM>();
            CommunityBL communityBL = new CommunityBL();
            communityList = communityBL.GetSubCommunityByCommunity(Id);
            return Json(communityList, JsonRequestBehavior.AllowGet);
        }
        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("Unable to create local account. An account with the name \"{0}\" may already exist.", User.Identity.Name));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
