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
  public class EmployerBL
    {
        UnitOfWork uow;

        public EmployerBL()
        {
            uow = new UnitOfWork();
        }

        public int Create(EmployerBM model)
        {
            Employer tech = ConvertToDM(model);
            uow.EmployerRepository.Add(tech);
            uow.Save();
            return tech.Id;
        }


        public List<EmployerBM> GetEmployer()
        {
            return uow.EmployerRepository.GetAll().ConvertAll<EmployerBM>(new Converter<Employer, EmployerBM>(ConvertToBM));
        }
      

        public EmployerBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.EmployerRepository.GetByID(id));
        }


        public void Update(EmployerBM model)
        {
            uow.EmployerRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private Employer ConvertToDM(EmployerBM model)
        {
            return new Employer
            {
                Id = model.Id,

                Email = model.Email,

                Password = model.Password,

                CountryId = model.CountryId,

                CompanyName = model.CompanyName,

                Website = model.Website,

                Description = model.Description,

                Path = model.Path,

                LocationId = model.LocationId,

                CompanyExtentionNumber = model.CompanyExtentionNumber,

                Address = model.Address,

                CompanyContactNumber = model.CompanyContactNumber,

                Username = model.Username,

                Designation = model.Designation,


                IsDeleted = model.IsDeleted,

                UserPhoneNumber = model.UserPhoneNumber,

                Active = model.Active,

                CreationDate = model.CreationDate,

                ModificationDate = model.ModificationDate,

                CreatedBy = model.CreatedBy,

                ModifiedBy = model.ModifiedBy

            };
        }

        private EmployerBM ConvertToBM(Employer model)
        {
            return new EmployerBM()
            {
                Id = model.Id,

                Email = model.Email,

                Password = model.Password,

                CountryId = model.CountryId,

                CompanyName = model.CompanyName,

                Website = model.Website,

                Description = model.Description,

                Path = model.Path,

                LocationId=model.LocationId,

                CompanyExtentionNumber = model.CompanyExtentionNumber,

                Address = model.Address,

                CompanyContactNumber=model.CompanyContactNumber,

                Username = model.Username,

                Designation = model.Designation,


                IsDeleted = model.IsDeleted,

                UserPhoneNumber = model.UserPhoneNumber,

                Active = model.Active,

                CreationDate = model.CreationDate,

                ModificationDate = model.ModificationDate,

                CreatedBy = model.CreatedBy,

                ModifiedBy = model.ModifiedBy

             




            };
        }

        public void Delete(EmployerBM model)
        {
            uow.EmployerRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
