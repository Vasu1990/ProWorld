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
    public class MasterUrlBL
    {
         UnitOfWork uow;

       public MasterUrlBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(MasterUrlBM model)
        {
            uow.MasterUrlRepository.Add(ConvertToDM(model));
            uow.Save();
        }


        public List<MasterUrlBM> GetLatestTechnology()
        {
            return uow.MasterUrlRepository.GetAll().ConvertAll<MasterUrlBM>(new Converter<MasterUrl, MasterUrlBM>(ConvertToBM));
        }


        public MasterUrlBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.MasterUrlRepository.GetByID(id));
        }


        public void Update(MasterUrlBM model)
        {
            uow.MasterUrlRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private MasterUrl ConvertToDM(MasterUrlBM model)
        {
            return new MasterUrl
            {
               
                Id=model.Id,

                ModuleId=model.ModuleId,

                Url=model.Url
            };
        }

        private MasterUrlBM ConvertToBM(MasterUrl model)
        {
            return new MasterUrlBM()
            {

                Id = model.Id,

                ModuleId = model.ModuleId,

                Url = model.Url


            };
        }

        public void Delete(MasterUrlBM model)
        {
            uow.MasterUrlRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
