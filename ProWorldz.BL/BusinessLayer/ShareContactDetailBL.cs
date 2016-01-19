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
   public class ShareContactDetailBL
    {
        UnitOfWork uow;

        public ShareContactDetailBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(ShareContactDetailBM model)
        {
            uow.ShareContactDetailRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<ShareContactDetailBM> GetShareContactDetail()
        {
            return uow.ShareContactDetailRepository.GetAll().ConvertAll<ShareContactDetailBM>(new Converter<ShareContactDetail, ShareContactDetailBM>(ConvertToBM));
        }
        //public List<ShareContactDetailBM> GetShareContactDetailByUserId(int Id)
        //{
        //    return uow.ShareContactDetailRepository.Find(a => a.StateId == Id).ConvertAll<ShareContactDetailBM>(new Converter<ShareContactDetail, ShareContactDetailBM>(ConvertToBM));
        //}
        public ShareContactDetailBM GetShareContactDetailById(int id)
        {
            return ConvertToBM(uow.ShareContactDetailRepository.GetByID(id));
        }


        public void Update(ShareContactDetailBM model)
        {
            uow.ShareContactDetailRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private ShareContactDetail ConvertToDM(ShareContactDetailBM model)
        {
            return new ShareContactDetail
            {

                 Id=model.Id,
              CurrentUserId=model.CurrentUserId,
              ShareUserId=model.ShareUserId,
              Message=model.Message,
              CreationDate=model.CreationDate,
              CreatedBy=model.CreatedBy,
              ModificationDate=model.ModificationDate,
              ModifiedBy=model.ModifiedBy,
             
              IsDeleted=model.IsDeleted

            };
        }

        private ShareContactDetailBM ConvertToBM(ShareContactDetail model)
        {
            return new ShareContactDetailBM()
            {
              
              Id=model.Id,
              CurrentUserId=model.CurrentUserId,
              ShareUserId=model.ShareUserId,
              Message=model.Message,
              CreationDate=model.CreationDate,
              CreatedBy=model.CreatedBy,
              ModificationDate=model.ModificationDate,
              ModifiedBy=model.ModifiedBy,
             
              IsDeleted=model.IsDeleted


            };
        }
    }
}
