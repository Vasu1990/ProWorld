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
   public class JobBL
    {
        UnitOfWork uow;

        public JobBL()
        {
            uow = new UnitOfWork();
        }

        public int Create(JobBM model)
        {
            Job tech = ConvertToDM(model);
            uow.JobRepository.Add(tech);
            uow.Save();
            return tech.Id;
        }


        public List<JobBM> GetJob()
        {
            return uow.JobRepository.GetAll().ConvertAll<JobBM>(new Converter<Job, JobBM>(ConvertToBM));
        }
      

        public JobBM GetTechnologyById(int id)
        {
            return ConvertToBM(uow.JobRepository.GetByID(id));
        }


        public void Update(JobBM model)
        {
            uow.JobRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private Job ConvertToDM(JobBM model)
        {
            return new Job
            {
                Id = model.Id,

                EmployerId=model.EmployerId,

                Headline=model.Headline,

                JobRole=model.JobRole,

                JobSkill=model.JobSkill,

                JobFunction=model.JobFunction,

                CountryId=model.CountryId,

                StateId=model.StateId,

                CityId=model.CityId,

                CommunityId=model.CommunityId,

                SubCommunityId=model.SubCommunityId,

                EducationQualificaation=model.EducationQualificaation,

                ExpYear=model.ExpYear,

                ExpMonth=model.ExpMonth,

                IndustryId=model.IndustryId,

                SalaryLakhs=model.SalaryLakhs,

                SalaryMonths=model.SalaryMonths,

                JobDescription=model.JobDescription,

                PostingDate=model.PostingDate,

                DateOfAdvExp=model.DateOfAdvExp,

                Email=model.Email,

                ContactPerson=model.ContactPerson,

                EmployementType=model.EmployementType,

                Active=model.Active,

                CreationDate=model.CreationDate,

                CreatedBy=model.CreatedBy,

                ModificationDate=model.ModificationDate,

                ModifiedBy=model.ModifiedBy,

                IsDeleted=model.IsDeleted

              

            };
        }

        private JobBM ConvertToBM(Job model)
        {
            return new JobBM()
            {
                Id = model.Id,

                EmployerId = model.EmployerId,

                Headline = model.Headline,

                JobRole = model.JobRole,

                JobSkill = model.JobSkill,

                JobFunction = model.JobFunction,

                CountryId = model.CountryId,

                StateId = model.StateId,

                CityId = model.CityId,

                CommunityId = model.CommunityId,

                SubCommunityId = model.SubCommunityId,

                EducationQualificaation = model.EducationQualificaation,

                ExpYear = model.ExpYear,

                ExpMonth = model.ExpMonth,

                IndustryId = model.IndustryId,

                SalaryLakhs = model.SalaryLakhs,

                SalaryMonths = model.SalaryMonths,

                JobDescription = model.JobDescription,

                PostingDate = model.PostingDate,

                DateOfAdvExp = model.DateOfAdvExp,

                Email = model.Email,

                ContactPerson = model.ContactPerson,

                EmployementType = model.EmployementType,

                Active = model.Active,

                CreationDate = model.CreationDate,

                CreatedBy = model.CreatedBy,

                ModificationDate = model.ModificationDate,

                ModifiedBy = model.ModifiedBy,

                IsDeleted = model.IsDeleted

             




            };
        }

        public void Delete(JobBM model)
        {
            uow.JobRepository.Delete(ConvertToDM(model));
            uow.Save();
        }
    }
}
