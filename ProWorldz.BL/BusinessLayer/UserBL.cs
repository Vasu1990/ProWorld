﻿using ProWorldz.BL.BusinessModel;
using ProWorldz.BL.Common.DatatablePaging;
using ProWorldz.DL.Models;
using ProWorldz.DL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessLayer
{
    public class UserBL
    {
        UnitOfWork uow;
        CountryBL countryBL = new CountryBL();
        CityBL cityBL = new CityBL();
        StateBL stateBL = new StateBL();
        UserGeneralInformationBL userGeneralInformationBL = new UserGeneralInformationBL();

        public UserBL()
        {
            uow = new UnitOfWork();
        }

        public int Create(UserBM model)
        {
            User user = ConvertToDM(model);
            uow.UserRepository.Add(user);
            uow.Save();
            return user.Id;
        }
        public List<UserBM> GetUsers()
        {
            return uow.UserRepository.GetAll().ConvertAll<UserBM>(new Converter<User, UserBM>(ConvertToBM));
        }

        public UserBM GetUserById(int id)
        {
            return ConvertToBM(uow.UserRepository.GetByID(id));
        }

        public void CreateUser(UserBM model)
        {
            uow.UserRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<UserBM> GeteUserByName(string searchTerm,DataTableParams param)
        {
            //Pagination logic Math.Min returns the least from both values
            var _searchQuery = param.SearchOptions.value == null ? searchTerm : param.SearchOptions.value;
            int RecordsToFetch = Math.Min(GetUserCountByName(_searchQuery) - param.RecordsToSkip, param.RecordsToTake);
            List<User> userList =   uow.UserRepository.Find(x=>x.Name.Contains(searchTerm));
            return userList.OrderBy(x => x.Name).Skip(param.RecordsToSkip).Take(RecordsToFetch).ToList().ConvertAll<UserBM>(new Converter<User, UserBM>(ConvertToBM));
            
        }
        public int GetUserCountByName(string searchTerm)
        {
            return uow.UserRepository.Find(x => x.Name.Contains(searchTerm)).Count();

        }
        public void UpdateUser(UserBM model)
        {
            uow.UserRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private User ConvertToDM(UserBM model)
        {
            if (model == null)
                return null;
            else
            return new User
            {
                Id=model.Id,
                Name = model.Name,
                Email = model.Email,
                Password=model.Password,
                UserTypeId=model.UserTypeId,
                DOB=model.DOB,
                Gender=model.Gender,
                CommunityId=model.CommunityId,
                CommunityName=model.CommunityName,
                SubCommunityId=model.SubCommunityId,
                SubCommunityName=model.SubCommunityName,
                Active = model.Active,
                CreationDate=model.CreationDate,
                CreatedBy=model.CreatedBy,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate,
                CityId=model.CityId,
                StateId=model.StateId,

                CountryId=model.CountryId,

                IsOnline = model.IsOnline




            };
        }

        private UserBM ConvertToBM(User model)
        {
            if (model == null)
                return null;
            else
            return new UserBM()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                UserTypeId = model.UserTypeId,
                DOB = model.DOB,
                Gender = model.Gender,
                CommunityId = model.CommunityId,
                CommunityName = model.CommunityName,
                SubCommunityId = model.SubCommunityId,
                SubCommunityName = model.SubCommunityName,
                Active = model.Active,
                ModifiedBy = model.ModifiedBy,
                ModificationDate = model.ModificationDate,
                CityId = model.CityId,
                StateId = model.StateId,

              CountryId= model.CountryId,
              CreationDate = model.CreationDate,

                IsOnline = model.IsOnline,
              CountryName=countryBL.GetCountryById(model.CountryId).Name,
              StateName=stateBL.GetStateById(model.StateId).Name,
              CityName=cityBL.GetCityById(model.CityId).Name
              



            };
        }

        #region Currently Not In Use
        public UserBM Login(string email, string password)
        {
            UserBM loggedUser = null;
            try
            {
                loggedUser = uow.UserRepository.Find(m => m.Email == email.Trim() && m.Password == password).Select(p => new UserBM { Name = p.Name, Id = p.Id, Active = p.Active }).Single();
            }
            catch (Exception)
            {
                loggedUser = null;
            }

            return loggedUser;

        }

        public bool CheckDuplicateUserName(string email)
        {
            return uow.UserRepository.Find(m => m.Name == email.Trim()).Count > 0 ? true : false;

        }

        //public bool CheckPassword(int UserID, string Password)
        //{
        //    return uow.UserLoginRepository.Find(m => m.UserID == UserID && m.Password == Password).Count > 0 ? true : false;
        //}

        public void ChangePassword(int UserID, string Password)
        {
            User updateModel = uow.UserRepository.GetByID(UserID);
            updateModel.Password = Password;
            uow.UserRepository.Update(updateModel);
            uow.Save();
        }
        #endregion
    }
}
