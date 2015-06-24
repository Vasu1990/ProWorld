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
    public class CityBL 
    {
         UnitOfWork uow;

         public CityBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(CityBM model)
        {
            uow.CityRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<CityBM> GetCities()
        {
            return uow.CityRepository.GetAll().ConvertAll<CityBM>(new Converter<City, CityBM>(ConvertToBM));
        }

        public CityBM GetCityById(int id)
        {
            return ConvertToBM(uow.CityRepository.GetByID(id));
        }


        public void Update(CityBM model)
        {
            uow.CityRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private City ConvertToDM(CityBM model)
        {
            return new City
            {
                 StateId = model.StateId,
                Id = model.Id,
                Name = model.Name
              

            };
        }

        private CityBM ConvertToBM(City model)
        {
            return new CityBM()
            {
                StateId = model.StateId,
                Id = model.Id,
                Name = model.Name
              


            };
        }
    }
}
