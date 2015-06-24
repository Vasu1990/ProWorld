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
   public class UserPersonalInformationBL
    {
         UnitOfWork uow;

         public UserPersonalInformationBL()
        {
            uow = new UnitOfWork();
        }

         public void Create(UserPersonalInformationBM model)
        {
            uow.UserPersonalInfomationRepository.Add(ConvertToDM(model));
            uow.Save();
        }
         public List<UserPersonalInformationBM> GetPersonalInformation()
        {
            return uow.UserPersonalInfomationRepository.GetAll().ConvertAll<UserPersonalInformationBM>(new Converter<UserPersonalInfomation, UserPersonalInformationBM>(ConvertToBM));
        }

         public UserPersonalInformationBM GetPersonalInformationById(int id)
        {
            return ConvertToBM(uow.UserPersonalInfomationRepository.GetByID(id));
        }

         public UserPersonalInformationBM GetPersonalInformationByUserId(int id)
         {
             return ConvertToBM(uow.UserPersonalInfomationRepository.Find(a=>a.UserId==id).FirstOrDefault());
         }
         public void Update(UserPersonalInformationBM model)
        {
            uow.UserPersonalInfomationRepository.Update(ConvertToDM(model));
            uow.Save();
        }

         private UserPersonalInfomation ConvertToDM(UserPersonalInformationBM model)
        {
            return new UserPersonalInfomation
            {
                Id = model.Id,
                UserId = model.UserId,
                Address1 = model.Address1,
                Address2 = model.Address2,
               // CityId = model.CityId,
               // StateId = model.StateId,
                PhoneNumber = model.Phone,

                CreatedBy = model.CreatedBy,
                CreationDate = model.CreationDate,

                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }

         private UserPersonalInformationBM ConvertToBM(UserPersonalInfomation model)
        {
            return new UserPersonalInformationBM()
            {
                Id = model.Id,
             UserId=model.UserId,
             Address1=model.Address1,
             Address2=model.Address2,
            // CityId=model.CityId,
             //StateId=model.StateId,
             Phone=model.PhoneNumber,

              CreatedBy=model.CreatedBy,
              CreationDate=model.CreationDate,

                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate


            };
        }
    }
}
