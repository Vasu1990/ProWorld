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
    public class MasterContentBL
    {
         UnitOfWork uow;

       public MasterContentBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(MasterContentBM model)
        {
            uow.MasterContentRepository.Add(ConvertToDM(model));
            uow.Save();
        }


        public List<MasterContentBM> GetLatestTechnology()
        {
            return uow.MasterContentRepository.GetAll().ConvertAll<MasterContentBM>(new Converter<MasterContent, MasterContentBM>(ConvertToBM));
        }


        public MasterContentBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.MasterContentRepository.GetByID(id));
        }


        public void Update(MasterContentBM model)
        {
            uow.MasterContentRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private MasterContent ConvertToDM(MasterContentBM model)
        {
            return new MasterContent
            {
               
                Id=model.Id,

                ModuleId=model.ModuleId,

                Content=model.Content
            };
        }

        private MasterContentBM ConvertToBM(MasterContent model)
        {
            return new MasterContentBM()
            {

                Id = model.Id,

                ModuleId = model.ModuleId,

                Content = model.Content


            };
        }

        public void Delete(MasterContentBM model)
        {
            uow.MasterContentRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
