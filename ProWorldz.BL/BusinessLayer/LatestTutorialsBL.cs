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
   public class LatestTutorialsBL
    {
       UnitOfWork uow;

        public LatestTutorialsBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(LatestTutorialsBM model)
        {
            uow.LatestTutorialsRepository.Add(ConvertToDM(model));
            uow.Save();
        }


        public List<LatestTutorialsBM> GetLatestTutorials()
        {
            return uow.LatestTutorialsRepository.GetAll().ConvertAll<LatestTutorialsBM>(new Converter<LatestTutorials, LatestTutorialsBM>(ConvertToBM));
        }
      

        public LatestTutorialsBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.LatestTutorialsRepository.GetByID(id));
        }


        public void Update(LatestTutorialsBM model)
        {
            uow.LatestTutorialsRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private LatestTutorials ConvertToDM(LatestTutorialsBM model)
        {
            return new LatestTutorials
            {
                Id = model.Id,

                CommunityId = model.CommunityId,

                SubCommunityId = model.SubCommunityId,

                Subject = model.Subject,

                Tag = model.Tag,

                Topic = model.Topic,

                Content = model.Content,

                Url = model.Url,

                VideoUrl = model.VideoUrl,

                FilePath = model.FilePath,

                IsActive = model.IsActive

            };
        }

        private LatestTutorialsBM ConvertToBM(LatestTutorials model)
        {
            return new LatestTutorialsBM()
            {
                Id = model.Id,

                CommunityId = model.CommunityId,

                SubCommunityId = model.SubCommunityId,

                Subject = model.Subject,

                Tag = model.Tag,

                Topic = model.Topic,

                Content = model.Content,

                Url = model.Url,

                VideoUrl = model.VideoUrl,

                FilePath = model.FilePath,

                IsActive = model.IsActive



            };
        }

        public void Delete(LatestTutorialsBM model)
        {
            uow.LatestTutorialsRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
