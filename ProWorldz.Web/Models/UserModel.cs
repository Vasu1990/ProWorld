using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProWorldz.Web.Models
{
    public class BaseModel
    {
        public string SucessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class PostCommentModel : BaseModel
    {
        public UserPostBM UserPost { get; set; }

        public List<UserPostBM> UserPostList { get; set; }
    }

    public class ViewProfileModel : BaseModel
    {
        
    }


    public class ProfileModel : BaseModel
    {
        public UserGeneralInformationBM UserGeneralInformationModel { get; set; }
        public UserPersonalInformationBM UserPersonalInformationModel { get; set; }
        public UserProfessionalQualificationBM UserProfessionalQualificationModel { get; set; }
        public UserQualificatinBM UserQualificatinModel { get; set; }
        CommonBL commonBL = new CommonBL();

        public UserVideoBM UserVideoModel { get; set; }

     //   public UserVideoBM UserVideoModel { get; set; }

        public List<CommunityBM> CommunityList { get; set; }
        public List<CommunityBM> SubCommunityList { get; set; }

        public List<CityBM> CityList { get; set; }
        public List<StateBM> StateList { get; set; }
        public List<CountryBM> CountryList { get; set; }

        public List<IndustryBM> IndustryList { get; set; }

        public List<DegreeBM> DegreeList { get; set; }

      //  public List<Designa> IndustryList { get; set; }

        public ProfileModel()
        {
            UserProfessionalQualificationModel = new UserProfessionalQualificationBM();
            IndustryList = commonBL.GetIndustry();
            DegreeList = commonBL.GetDegree();
            UserGeneralInformationModel = new UserGeneralInformationBM();
            UserPersonalInformationModel = new UserPersonalInformationBM();
            UserProfessionalQualificationModel = new UserProfessionalQualificationBM();
            UserQualificatinModel = new UserQualificatinBM();
            UserVideoModel = new UserVideoBM();

        }
    }
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name enter please")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int UserTypeId { get; set; }

        [Required]
        public DateTime DOB { get; set; }
         [Required]
        public string DateOfBirth { get; set; }
        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public string Gender { get; set; }

        public System.DateTime CreationDate { get; set; }

        public Nullable<System.DateTime> ModificationDate { get; set; }

        public int CreatedBy { get; set; }

        public Nullable<int> ModifiedBy { get; set; }

        [Required]
        public int CommunityId { get; set; }
        [Required]
        public int SubCommunityId { get; set; }

        public int CommunityName { get; set; }

        public int SubCommunityName { get; set; }


        public List<CommunityBM> CommunityList { get; set; }
        public List<CommunityBM> SubCommunityList { get; set; }
    }
}