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
   public class CommonBL
    {
      
        UnitOfWork uow;

        public CommonBL()
        {
            uow = new UnitOfWork();
        }
         public  List<IndustryBM> GetIndustry()
         {
             List<IndustryBM> IndustryList = uow.IndustryTypeRepository.GetAll().ConvertAll<IndustryBM>(new Converter<IndustryType, IndustryBM>(ConvertToIndustryBM));
          return IndustryList;
         }
         public List<DegreeBM> GetDegree()
         {
             List<DegreeBM> DegreList = uow.DegreeRepository.GetAll().ConvertAll<DegreeBM>(new Converter<Degree, DegreeBM>(ConvertToDegreeBM)); ;
             return DegreList;
         }

         #region convert methods
         private IndustryType ConvertToIndustryDM(IndustryBM model)
         {
             return new IndustryType
             {
                 Id = model.Id,
                 Name = model.Name,
              

             };
         }

         private IndustryBM ConvertToIndustryBM(IndustryType model)
         {
             return new IndustryBM()
             {
                 Id = model.Id,
                 Name = model.Name,
                
             };
         }

         private Degree ConvertToDegreeDM(DegreeBM model)
         {
             return new Degree
             {
                 Id = model.Id,
                 Name = model.Name,


             };
         }

         private DegreeBM ConvertToDegreeBM(Degree model)
         {
             return new DegreeBM()
             {
                 Id = model.Id,
                 Name = model.Name,

             };
         }
        #endregion
    }
}
