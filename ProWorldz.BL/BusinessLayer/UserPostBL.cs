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
            return new UserPost
            {
                Id = model.Id,
               UserId=model.UserId,
               Subject=model.Subject,
               Post=model.Post,
               CreatedBy=model.CreatedBy,
               CreationDate=model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate




            };
        }

        private UserPostBM ConvertToBM(UserPost model)
        {
            return new UserPostBM()
            {
                Id = model.Id,
               UserId=model.UserId,
               UserName=model.User.Name,
               Subject=model.Subject,
               Post=model.Post,
               CreatedBy=model.CreatedBy,
               CreationDate=model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }
    }
}
