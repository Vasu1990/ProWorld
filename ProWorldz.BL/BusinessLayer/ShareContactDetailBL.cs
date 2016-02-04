using ProWorldz.BL.BusinessModel;
using ProWorldz.DL.Models;
using ProWorldz.DL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessLayer
{
   public class ShareContactDetailBL
    {
        UnitOfWork uow;

        public ShareContactDetailBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(ShareContactDetailBM model)
        {
            uow.ShareContactDetailRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<ShareContactDetailBM> GetShareContactDetail()
        {
            return uow.ShareContactDetailRepository.GetAll().ConvertAll<ShareContactDetailBM>(new Converter<ShareContactDetail, ShareContactDetailBM>(ConvertToBM));
        }
        //public List<ShareContactDetailBM> GetShareContactDetailByUserId(int Id)
        //{
        //    return uow.ShareContactDetailRepository.Find(a => a.StateId == Id).ConvertAll<ShareContactDetailBM>(new Converter<ShareContactDetail, ShareContactDetailBM>(ConvertToBM));
        //}
        public ShareContactDetailBM GetShareContactDetailById(int id)
        {
            return ConvertToBM(uow.ShareContactDetailRepository.GetByID(id));
        }


        public List<ShareContactDetailBM> GetShareContactDetailByCurrentUserId(int CurrentUserId)
        {
            return uow.ShareContactDetailRepository.Find(a => a.ShareUserId == CurrentUserId).ToList().ConvertAll<ShareContactDetailBM>(new Converter<ShareContactDetail, ShareContactDetailBM>(ConvertToBM));
        }

        public void Update(ShareContactDetailBM model)
        {
            uow.ShareContactDetailRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private ShareContactDetail ConvertToDM(ShareContactDetailBM model)
        {
            return new ShareContactDetail
            {

                 Id=model.Id,
              CurrentUserId=model.CurrentUserId,
              ShareUserId=model.ShareUserId,
              Message=model.Message,
              CreationDate=model.CreationDate,
              CreatedBy=model.CreatedBy,
              ModificationDate=model.ModificationDate,
              ModifiedBy=model.ModifiedBy,
             
              IsDeleted=model.IsDeleted

            };
        }
       // UserBL userBL = new UserBL();

        UserGeneralInformationBL userGeneralInfoBL = new UserGeneralInformationBL();
        UserBL userBL = new UserBL();

        UserProfessionalQualificationBL userProfessionalQualificationBL = new UserProfessionalQualificationBL();
        private ShareContactDetailBM ConvertToBM(ShareContactDetail model)
        {
            UserGeneralInformationBM usergeneralInfoBM = new UserGeneralInformationBM();
            UserProfessionalQualificationBM userProfessionalBM = new UserProfessionalQualificationBM();

            UserBM userBM=new UserBM();

            userBM=userBL.GetUserById(model.ShareUserId);

            usergeneralInfoBM = userGeneralInfoBL.GetGeneralInformationByUserId(model.ShareUserId);
            userProfessionalBM = userProfessionalQualificationBL.GetProfessionalQualificationByUserId(model.ShareUserId).FirstOrDefault();
            return new ShareContactDetailBM()
            {
              
              Id=model.Id,
              CurrentUserId=model.CurrentUserId,
              ShareUserId=model.ShareUserId,
              Message=model.Message,
              CreationDate=model.CreationDate,
              CreatedBy=model.CreatedBy,
              ModificationDate=model.ModificationDate,
              ModifiedBy=model.ModifiedBy,
             
             Email=userBM!=null? userBM.Email:"",
            Phone=usergeneralInfoBM !=null ?  usergeneralInfoBM.PhoneNumber :"",
            Company=userProfessionalBM !=null ?userProfessionalBM.CompanyName:"",
            //  Designation = userProfessionalBM != null ? userProfessionalBM.Designation : "",

              IsDeleted=model.IsDeleted,
              userBM = userBL.GetUserById(model.CurrentUserId)

            };
        }
    }
}
