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
    public class UserGeneralInformationBL
    {
        UnitOfWork uow;

        public UserGeneralInformationBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(UserGeneralInformationBM model)
        {
            uow.UserGeneralInfomationRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<UserGeneralInformationBM> GetGeneralInformation()
        {
            return uow.UserGeneralInfomationRepository.GetAll().ConvertAll<UserGeneralInformationBM>(new Converter<UserGeneralInfomation, UserGeneralInformationBM>(ConvertToBM));
        }

        public UserGeneralInformationBM GetGeneralInformationById(int id)
        {
            return ConvertToBM(uow.UserGeneralInfomationRepository.GetByID(id));
        }
        public UserGeneralInformationBM GetGeneralInformationByUserId(int UserId)
        {

            return ConvertToBM(uow.UserGeneralInfomationRepository.Find(p => p.UserId == UserId).FirstOrDefault());
        }

        public void Update(UserGeneralInformationBM model)
        {
            uow.UserGeneralInfomationRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserGeneralInfomation ConvertToDM(UserGeneralInformationBM model)
        {
            UserBL userBL = new UserBL();
            if (model == null)
                return null;
            else
                return new UserGeneralInfomation
                {
                    Id = model.Id,
                    Address1=model.Address1,
                    Address2=model.Address2,
                    PhoneNumber=model.PhoneNumber,
                    FatherName=model.FatherName,
                    Status=model.Status,
                   // CommunityId = userBL.GetUserById(model.UserId).CommunityId,
                   // SubCommunityId = userBL.GetUserById(model.UserId).SubCommunityId,
                    Image = model.Image,
                    Active = model.Active,
                    CreatedBy = model.CreatedBy,
                    CreationDate = model.CreationDate,
                    UserId = model.UserId,
                    ModifiedBy = model.ModifiedBy,
                    ModificationDate = model.ModificationDate


                };
        }

        private UserGeneralInformationBM ConvertToBM(UserGeneralInfomation model)
        {
            UserBL userBL = new UserBL();
            if (model == null)
                return null;
            else
                return new UserGeneralInformationBM()
                {
                    Id = model.Id,

                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    PhoneNumber = model.PhoneNumber,
                    FatherName = model.FatherName,
                    Status = model.Status,

                    CommunityId = userBL.GetUserById(model.UserId).CommunityId,
                    SubCommunityId = userBL.GetUserById(model.UserId).SubCommunityId,
                    Image = model.Image,
                    CreatedBy = model.CreatedBy,
                    CreationDate = model.CreationDate,
                    UserId = model.UserId,
                    ModifiedBy = model.ModifiedBy,
                    ModificationDate = model.ModificationDate
                };
        }
    }
}
