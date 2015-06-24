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
   public class UserPostCommentCommentBL
    {
        UnitOfWork uow;

        public UserPostCommentCommentBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(UserPostCommentBM model)
        {
            uow.UserPostCommentRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<UserPostCommentBM> GetUserPostComment()
        {
            return uow.UserPostCommentRepository.GetAll().ConvertAll<UserPostCommentBM>(new Converter<UserPostComment, UserPostCommentBM>(ConvertToBM));
        }

        public UserPostCommentBM GetUserPostCommentById(int id)
        {
            return ConvertToBM(uow.UserPostCommentRepository.GetByID(id));
        }


        public void Updat(UserPostCommentBM model)
        {
            uow.UserPostCommentRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserPostComment ConvertToDM(UserPostCommentBM model)
        {
            return new UserPostComment
            {
                Id = model.Id,
               UserId=model.UserId,
               Comment=model.Comment,
               PostId=model.PostId,
               CreatedBy=model.CreatedBy,
               CreationDate=model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate



            };
        }

        private UserPostCommentBM ConvertToBM(UserPostComment model)
        {
            return new UserPostCommentBM()
            {
                Id = model.Id,
               UserId=model.UserId,
               Comment=model.Comment,
               PostId=model.PostId,
               CreatedBy=model.CreatedBy,
               CreationDate=model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }
    }
}
