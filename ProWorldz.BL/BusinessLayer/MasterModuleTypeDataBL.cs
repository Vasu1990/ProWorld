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
   public class MasterModuleTypeDataBL
    {
        UnitOfWork uow;

       public MasterModuleTypeDataBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(MasterModuleTypeDataBM model)
        {
            uow.MasterModuleTypeDataRepository.Add(ConvertToDM(model));
            uow.Save();
        }


        public List<MasterModuleTypeDataBM> GetMasterModuleTypeData()
        {
            return uow.MasterModuleTypeDataRepository.GetAll().ConvertAll<MasterModuleTypeDataBM>(new Converter<MasterModuleTypeData, MasterModuleTypeDataBM>(ConvertToBM));
        }


        public MasterModuleTypeDataBM GetMasterModuleTypeDataById(int id)
        {
            return ConvertToBM(uow.MasterModuleTypeDataRepository.GetByID(id));
        }


        public void Update(MasterModuleTypeDataBM model)
        {
            uow.MasterModuleTypeDataRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private MasterModuleTypeData ConvertToDM(MasterModuleTypeDataBM model)
        {
            return new MasterModuleTypeData
            {


                Id = model.Id,
                ModuleId = model.ModuleId,
                ModuleTypeId = model.ModuleTypeId,
                Data = model.Data

             
            };
        }

        private MasterModuleTypeDataBM ConvertToBM(MasterModuleTypeData model)
        {
            return new MasterModuleTypeDataBM()
            {

                Id = model.Id,
               ModuleId=model.ModuleId,
               ModuleTypeId=model.ModuleTypeId,
               Data=model.Data
          


            };
        }

        public void Delete(MasterModuleTypeDataBM model)
        {
            uow.MasterModuleTypeDataRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
