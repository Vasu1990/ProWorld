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
   public class CountryBL
    {
       UnitOfWork uow;

       public CountryBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(CountryBM model)
        {
            uow.CountryRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<CountryBM> GetCountry()
        {
            return uow.CountryRepository.GetAll().ConvertAll<CountryBM>(new Converter<Country, CountryBM>(ConvertToBM));
        }

        public CountryBM GetCountryById(int id)
        {
            return ConvertToBM(uow.CountryRepository.GetByID(id));
        }


        public void Update(CountryBM model)
        {
            uow.CountryRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private Country ConvertToDM(CountryBM model)
        {
            return new Country
            {
               CountryId = model.CountryId,
              Name=model.Name,
               CreatedBy=model.CreatedBy,
               CreationDate=model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate



            };
        }

        private CountryBM ConvertToBM(Country model)
        {
            return new CountryBM()
            {
                CountryId = model.CountryId,
              Name=model.Name,
               CreatedBy=model.CreatedBy,
               CreationDate=model.CreationDate,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }
    }
}
