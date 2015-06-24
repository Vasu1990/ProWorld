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
    public class UserProfessionalQualificationBL
    {


        UnitOfWork uow;

        public UserProfessionalQualificationBL()
        {
            uow = new UnitOfWork();
        }
        public void Create(UserProfessionalQualificationBM model)
        {
            uow.UserProfessionalQualificationRepository.Add(ConvertToDM(model));
            uow.Save();
        }

        public List<UserProfessionalQualificationBM> GetProfessionalQualification()
        {
            return uow.UserProfessionalQualificationRepository.GetAll().ConvertAll<UserProfessionalQualificationBM>(new Converter<UserProfessionalQualification, UserProfessionalQualificationBM>(ConvertToBM));
        }

        public UserProfessionalQualificationBM GetProfessionalQualificationById(int id)
        {
            return ConvertToBM(uow.UserProfessionalQualificationRepository.GetByID(id));
        }

        public List<UserProfessionalQualificationBM> GetProfessionalQualificationByUserId(int id)
        {
            return  uow.UserProfessionalQualificationRepository.Find(k=>k.UserId==id).ConvertAll<UserProfessionalQualificationBM>(new Converter<UserProfessionalQualification, UserProfessionalQualificationBM>(ConvertToBM));
        }

        public void CreateProfessionalQualification(UserProfessionalQualificationBM model)
        {
            uow.UserProfessionalQualificationRepository.Add(ConvertToDM(model));
            uow.Save();
        }

        public void Update(UserProfessionalQualificationBM model)
        {
            uow.UserProfessionalQualificationRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserProfessionalQualification ConvertToDM(UserProfessionalQualificationBM model)
        {
            return new UserProfessionalQualification
            {
                Id = model.Id,
                UserId = model.UserId,
                CompanyName = model.CompanyName,
                StartDate = model.StartDate == DateTime.MinValue ? DateTime.Now.Date : model.StartDate,
                EndDate = model.EndDate == DateTime.MinValue ? DateTime.Now.Date : model.StartDate,
                Designation = model.Designation,
                Salary = model.Salary,
                CurrentIndustry = model.IndustryTypeId,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,
                IsCurrentEmployee = model.IsCurrentEmployee,
                UserRole=model.UserRole,
                Skill=model.Skill,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate
            };
        }

        private UserProfessionalQualificationBM ConvertToBM(UserProfessionalQualification model)
        {
            return new UserProfessionalQualificationBM()
            {
                Id = model.Id,
                UserId = model.UserId,
                CompanyName = model.CompanyName,
                StartDate = model.StartDate == DateTime.MinValue ? DateTime.Now.Date : model.StartDate,
                EndDate = model.EndDate == DateTime.MinValue ? DateTime.Now.Date : model.StartDate,
                Designation = model.Designation,
                Salary = model.Salary,
                IndustryTypeId = model.CurrentIndustry,
                CreatedBy = model.CreatedBy,
                UserRole = model.UserRole,
                Skill = model.Skill,
                CreationDate = model.CreationDate,
                IsCurrentEmployee = model.IsCurrentEmployee,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }
    }
}
