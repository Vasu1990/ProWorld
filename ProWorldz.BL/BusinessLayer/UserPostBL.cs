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
    public class UserPostBL
    {
        UnitOfWork uow;

        public UserPostBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(UserPostBM model)
        {
            uow.UserPostRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<UserPostBM> GetUserPost()
        {

            return uow.UserPostRepository.GetAll().ConvertAll<UserPostBM>(new Converter<UserPost, UserPostBM>(ConvertToBM));
        }

        public UserPostBM GetUserPostById(int id)
        {
            return ConvertToBM(uow.UserPostRepository.GetByID(id));
        }


        public void Update(UserPostBM model)
        {
            uow.UserPostRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserPost ConvertToDM(UserPostBM model)
        {
            if (model == null)
                return null;
            else
            return new UserPost
            {
                Id = model.Id,
                UserId = model.UserId,
                Subject = model.Subject,
                Post = model.Post,
                PostType=model.PostType,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate
            };
        }

        private UserPostBM ConvertToBM(UserPost model)
        {
            if (model == null)
                return null;
            else
            return new UserPostBM()
            {
                Id = model.Id,
                UserId = model.UserId,
                UserName = model.User.Name,
                ImageUrl = model.User.UserGeneralInfo.Where(x => x.UserId == model.UserId).Select(x => x.Image).FirstOrDefault(),
                Subject = model.Subject,
                Post = model.Post,
                PostType = model.PostType,
                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate,
                //WHICH ONE IS BETTER??
                //done by lazy loading
                UserComments = model.UserComments.Select(data => ConvertToCommentBM(data)).ToList()
                //done by repo call
                //UserComments = uow.UserPostCommentRepository.Find(x=>x.PostId == model.Id).ConvertAll<UserPostCommentBM>(new Converter<UserPostComment, UserPostCommentBM>(ConvertToCommentBM))
            };
        }


        private UserPostCommentBM ConvertToCommentBM(UserPostComment c)
        {
            return new UserPostCommentBM()
                  {
                      Id = c.Id,
                      UserId = c.UserId,
                      UserName = c.User.Name,
                      Comment = c.Comment,
                      PostId = c.PostId,
                      CreatedBy = c.CreatedBy,
                      CreationDate = c.CreationDate,
                      ModificationDate = c.ModificationDate,
                      ImageUrl = c.User.UserGeneralInfo.Select(x=>x.Image).FirstOrDefault()

                  };
        }
    }
}