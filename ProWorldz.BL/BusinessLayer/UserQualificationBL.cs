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
   public class UserQualificationBL
    {

         UnitOfWork uow;

          public UserQualificationBL()
        {
            uow = new UnitOfWork();
        }

         public void Create(UserQualificatinBM model)
        {
            uow.UserQualificationRepository.Add(ConvertToDM(model));
            uow.Save();
        }
         public List<UserQualificatinBM> GetUserQualificatin()
        {
            return uow.UserQualificationRepository.GetAll().ConvertAll<UserQualificatinBM>(new Converter<UserQualification, UserQualificatinBM>(ConvertToBM));
        }

         public UserQualificatinBM GetUserQualificatinById(int id)
        {
            return ConvertToBM(uow.UserQualificationRepository.GetByID(id));
        }
         public List<UserQualificatinBM> GetUserQualificatinByUserId(int id)
         {
             return uow.UserQualificationRepository.Find(d=>d.UserId==id).ConvertAll<UserQualificatinBM>(new Converter<UserQualification, UserQualificatinBM>(ConvertToBM));
         }
         public void CreateUserQualificatin(UserQualificatinBM model)
        {
            uow.UserQualificationRepository.Add(ConvertToDM(model));
            uow.Save();
        }

         public void Update(UserQualificatinBM model)
        {
            uow.UserQualificationRepository.Update(ConvertToDM(model));
            uow.Save();
        }

         private UserQualification ConvertToDM(UserQualificatinBM model)
        {
            return new UserQualification
            {
                Id = model.Id,
                UserId = model.UserId,
               SchoolName=model.SchoolName,
               DegreeName=model.Degree,
               Percentage=model.Percentage,
               Description=model.Description,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,
                StartDate=model.StartDate,
                EndDate=model.EndDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate
            };
        }

         private UserQualificatinBM ConvertToBM(UserQualification model)
        {
            return new UserQualificatinBM()
            {
                Id = model.Id,
                UserId = model.UserId,
                SchoolName = model.SchoolName,
                Degree = model.DegreeName,
                Percentage = model.Percentage,
                Description = model.Description,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate

            };
        }
    }
}
