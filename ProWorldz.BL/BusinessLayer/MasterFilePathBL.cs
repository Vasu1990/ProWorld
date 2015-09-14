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
   public class MasterFilePathBL
    {
       UnitOfWork uow;

       public MasterFilePathBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(MasterFilePathBM model)
        {
            uow.MasterFilePathRepository.Add(ConvertToDM(model));
            uow.Save();
        }


        public List<MasterFilePathBM> GetLatestTechnology()
        {
            return uow.MasterFilePathRepository.GetAll().ConvertAll<MasterFilePathBM>(new Converter<MasterFilePath, MasterFilePathBM>(ConvertToBM));
        }


        public MasterFilePathBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.MasterFilePathRepository.GetByID(id));
        }


        public void Update(MasterFilePathBM model)
        {
            uow.MasterFilePathRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private MasterFilePath ConvertToDM(MasterFilePathBM model)
        {
            return new MasterFilePath
            {
               
                Id=model.Id,

                ModuleId=model.ModuleId,

                FilePath=model.FilePath
            };
        }

        private MasterFilePathBM ConvertToBM(MasterFilePath model)
        {
            return new MasterFilePathBM()
            {

                Id = model.Id,

                ModuleId = model.ModuleId,

                FilePath = model.FilePath


            };
        }

        public void Delete(MasterFilePathBM model)
        {
            uow.MasterFilePathRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
