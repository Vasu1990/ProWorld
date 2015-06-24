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
   public class StateBL
    {
        UnitOfWork uow;

        public StateBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(StateBM model)
        {
            uow.StateRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<StateBM> GetState()
        {
            return uow.StateRepository.GetAll().ConvertAll<StateBM>(new Converter<State, StateBM>(ConvertToBM));
        }

        public StateBM GetStateById(int id)
        {
            return ConvertToBM(uow.StateRepository.GetByID(id));
        }


        public void Update(StateBM model)
        {
            uow.StateRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private State ConvertToDM(StateBM model)
        {
            return new State
            {
                StateId=model.StateId,
                CountryId=model.StateId,
                Name=model.Name
              
            };
        }

        private StateBM ConvertToBM(State model)
        {
            return new StateBM()
            {
                StateId = model.StateId,
                CountryId = model.StateId,
                Name = model.Name
              


            };
        }
    }
}
