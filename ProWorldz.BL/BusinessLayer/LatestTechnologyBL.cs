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
    public class LatestTechnologyBL
    {

        UnitOfWork uow;

        public LatestTechnologyBL()
        {
            uow = new UnitOfWork();
        }

        public int Create(LatestTechnologyBM model)
        {
            LatestTechnology tech = ConvertToDM(model);
            uow.LatestTechnologyRepository.Add(tech);
            uow.Save();
            return tech.Id;
        }



        public int GetEarnPoints(int userId)
        {
            LatestTutorialsBL latestTutorialBL = new LatestTutorialsBL();

            List<LatestTechnologyBM> LatestTechnologyList=new List<LatestTechnologyBM>();

            List<LatestTutorialsBM> LatestTutorialsList = new List<LatestTutorialsBM>();

            LatestTechnologyList = this.GetTechnologyByUserId(userId);



            LatestTutorialsList = latestTutorialBL.GetTechnologyByUserId(userId);



            int points = 0;
            points = LatestTechnologyList.Sum(a => a.EarnPoint);

            points+=LatestTutorialsList.Sum(a => a.EarnPoint);
            return points;
        }




        public List<LatestTechnologyBM> GetLatestTechnology()
        {
            return uow.LatestTechnologyRepository.GetAll().ConvertAll<LatestTechnologyBM>(new Converter<LatestTechnology, LatestTechnologyBM>(ConvertToBM));
        }
      

        public LatestTechnologyBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.LatestTechnologyRepository.GetByID(id));
        }
        public List<LatestTechnologyBM> GetTechnologyByUserId(int id)
        {
            return uow.LatestTechnologyRepository.Find(a=>a.UserId==id).ConvertAll<LatestTechnologyBM>(new Converter<LatestTechnology, LatestTechnologyBM>(ConvertToBM));
        }

        public void Update(LatestTechnologyBM model)
        {
            uow.LatestTechnologyRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private LatestTechnology ConvertToDM(LatestTechnologyBM model)
        {
            return new LatestTechnology
            {
                Id = model.Id,

                CommunityId = model.CommunityId,

                SubCommunityId = model.SubCommunityId,

                UserId=model.UserId,

                Subject = model.Subject,

                Tag = model.Tag,

                Topic = model.Topic,

                Content = model.Content,

                Url = model.Url,

                VideoUrl = model.VideoUrl,

                FilePath = model.FilePath,

                EarnPoint=model.EarnPoint,

                IsActive = model.IsActive

            };
        }

        private LatestTechnologyBM ConvertToBM(LatestTechnology model)
        {
            return new LatestTechnologyBM()
            {
                Id = model.Id,

                CommunityId = model.CommunityId,

                SubCommunityId = model.SubCommunityId,

                UserId = model.UserId,

                Subject = model.Subject,

                Tag = model.Tag,

                Topic = model.Topic,

                Content = model.Content,

                Url = model.Url,

                VideoUrl = model.VideoUrl,

                EarnPoint = model.EarnPoint,

                FilePath = model.FilePath,

                IsActive = model.IsActive



            };
        }

        public void Delete(LatestTechnologyBM model)
        {
            uow.LatestTechnologyRepository.Delete(ConvertToDM(model));
            uow.Save();
        }


    }
}
