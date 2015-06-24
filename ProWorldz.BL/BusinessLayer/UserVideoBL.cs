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
    public class UserVideoBL
    {
        UnitOfWork uow;

        public UserVideoBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(UserVideoBM model)
        {
            uow.UserVideoRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<UserVideoBM> GetUserVideo()
        {
            return uow.UserVideoRepository.GetAll().ConvertAll<UserVideoBM>(new Converter<UserVideo, UserVideoBM>(ConvertToBM));
        }

        public UserVideoBM GetById(int id)
        {
            return ConvertToBM(uow.UserVideoRepository.GetByID(id));
        }

        public UserVideoBM GetByUserId(int id)
        {
            return ConvertToBM(uow.UserVideoRepository.Find(j=>j.UserId==id).FirstOrDefault());
        }

    

        public void Update(UserVideoBM model)
        {
            uow.UserVideoRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserVideo ConvertToDM(UserVideoBM model)
        {
            return new UserVideo
            {
                Id = model.Id,
                UserId = model.UserId,
                VideoResumeUrl=model.VideoResumeUrl,
                ArtWorkYouTube1 = model.ArtWorkYouTube1,
                ArtWorkYouTube2 = model.ArtWorkYouTube2,
                ArtWorkYouTube3 = model.ArtWorkYouTube3,
                ArtWorkYouTube4 = model.ArtWorkYouTube4,
                ArtWorkYouTube5 = model.ArtWorkYouTube5,

                ArtWorkUrl1 = model.ArtWorkUrl1,
                ArtWorkUrl2 = model.ArtWorkUrl2,
                ArtWorkUrl3 = model.ArtWorkUrl3,


                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,

                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate
            };
        }

        private UserVideoBM ConvertToBM(UserVideo model)
        {
            return new UserVideoBM()
            {
                Id = model.Id,
                UserId = model.UserId,
                VideoResumeUrl=model.VideoResumeUrl,
                ArtWorkYouTube1 = model.ArtWorkYouTube1,
                ArtWorkYouTube2 = model.ArtWorkYouTube2,
                ArtWorkYouTube3 = model.ArtWorkYouTube3,
                ArtWorkYouTube4 = model.ArtWorkYouTube4,
                ArtWorkYouTube5 = model.ArtWorkYouTube5,

                ArtWorkUrl1=model.ArtWorkUrl1,
                ArtWorkUrl2=model.ArtWorkUrl2,
                ArtWorkUrl3=model.ArtWorkUrl3,
            

                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,

                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate

            };
        }
    }
}
