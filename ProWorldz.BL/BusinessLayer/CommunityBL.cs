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
  public  class CommunityBL
    {

        UnitOfWork uow;

        public CommunityBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(CommunityBM model)
        {
            uow.CommunityRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<CommunityBM> GetCommunity()
        {
            return uow.CommunityRepository.GetAll().ConvertAll<CommunityBM>(new Converter<Community, CommunityBM>(ConvertToBM));
        }

        public CommunityBM GetUserById(int id)
        {
            return ConvertToBM(uow.CommunityRepository.GetByID(id));
        }

        public void CreateUser(CommunityBM model)
        {
            uow.CommunityRepository.Add(ConvertToDM(model));
            uow.Save();
        }

        public void UpdateUser(CommunityBM model)
        {
            uow.CommunityRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private Community ConvertToDM(CommunityBM model)
        {
            return new Community
            {
                Id=model.Id,
                Name = model.Name,
                ParentId = model.ParentId,
             
                Active = model.Active,
                CreationDate=model.CreationDate,
                CreatedBy=model.CreatedBy,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate



            };
        }

        private CommunityBM ConvertToBM(Community model)
        {
            return new CommunityBM()
            {
                Id = model.Id,
                Name = model.Name,
                ParentId = model.ParentId,
             
                Active = model.Active,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }
    }
}
