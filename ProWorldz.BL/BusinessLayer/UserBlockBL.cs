using ProWorldz.BL.BusinessModel;
using ProWorldz.DL.Migrations;
using ProWorldz.DL.Models;
using ProWorldz.DL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessLayer
{
   public class UserBlockBL
    {
        UnitOfWork uow;

        public UserBlockBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(UserBlockBM model)
        {
            uow.UserBlockRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<UserBlockBM> GetUserBlock()
        {
            return uow.UserBlockRepository.GetAll().ConvertAll<UserBlockBM>(new Converter<UserBlock, UserBlockBM>(ConvertToBM));
        }
        //public List<UserBlockBM> GetUserBlockByUserId(int Id)
        //{
        //    return uow.UserBlockRepository.Find(a => a.StateId == Id).ConvertAll<UserBlockBM>(new Converter<UserBlock, UserBlockBM>(ConvertToBM));
        //}
        public UserBlockBM GetUserBlockById(int id)
        {
            return ConvertToBM(uow.UserBlockRepository.GetByID(id));
        }


        public void Update(UserBlockBM model)
        {
            uow.UserBlockRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private UserBlock ConvertToDM(UserBlockBM model)
        {
            return new UserBlock
            {

                Id = model.Id,
                CurrentUserId = model.CurrentUserId,
                ShareUserId = model.ShareUserId,
                IsBlock = model.IsBlock,
                IsFollow = model.IsFollow,
                CreationDate = model.CreationDate,
                CreatedBy = model.CreatedBy,
                ModificationDate = model.ModificationDate,
                ModifiedBy = model.ModifiedBy,
                Active = model.Active,
                IsDeleted = model.IsDeleted

            };
        }

        private UserBlockBM ConvertToBM(UserBlock model)
        {
            return new UserBlockBM()
            {
              
              Id=model.Id,
              CurrentUserId=model.CurrentUserId,
              ShareUserId=model.ShareUserId,
              IsBlock=model.IsBlock,
              IsFollow = model.IsFollow,
              CreationDate=model.CreationDate,
              CreatedBy=model.CreatedBy,
              ModificationDate=model.ModificationDate,
              ModifiedBy=model.ModifiedBy,
              Active=model.Active,
              IsDeleted=model.IsDeleted


            };
        }
    }
}
