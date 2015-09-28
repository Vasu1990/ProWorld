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
   public class UserResumeBL
    {
         UnitOfWork uow;

       public UserResumeBL()
        {
            uow = new UnitOfWork();
        }

        public int Create(UserResumeBM model)
        {
         


            UserResume tech = ConvertToDM(model);
            uow.UserResumeRepository.Add(tech);
            uow.Save();
            return tech.Id;
        }


        public List<UserResumeBM> GetUserResume()
        {
            return uow.UserResumeRepository.GetAll().ConvertAll<UserResumeBM>(new Converter<UserResume, UserResumeBM>(ConvertToBM));
        }


        public UserResumeBM GetUserResumeById(int id)
        {
            return ConvertToBM(uow.UserResumeRepository.GetByID(id));
        }


        public void Update(UserResumeBM model)
        {
            uow.UserResumeRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserResume ConvertToDM(UserResumeBM model)
        {
            return new UserResume
            {

                Id = model.Id,
                UserId = model.UserId,
                IsVisaHolder = model.IsVisaHolder,

                IsForeignWorker = model.IsForeignWorker,
                TotalExperience = model.TotalExperience,
                ResumePath = model.ResumePath,

                CoverLetterPath = model.CoverLetterPath,
                ResumeContent = model.ResumeContent,
                CoverLetterContent = model.CoverLetterContent

             
            };
        }

        private UserResumeBM ConvertToBM(UserResume model)
        {
            return new UserResumeBM()
            {

                Id = model.Id,
                UserId=model.UserId,
                IsVisaHolder=model.IsVisaHolder,

                IsForeignWorker=model.IsForeignWorker,
                TotalExperience=model.TotalExperience,
                ResumePath=model.ResumePath,

                CoverLetterPath=model.CoverLetterPath,
                ResumeContent=model.ResumeContent,
                CoverLetterContent=model.CoverLetterContent
          


            };
        }

        public void Delete(UserResumeBM model)
        {
            uow.UserResumeRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
