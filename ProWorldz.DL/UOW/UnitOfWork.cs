using ProWorldz.DL.Interfaces;
using ProWorldz.DL.Models;
using ProWorldz.DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.UOW
{
    public class UnitOfWork:IDisposable
    {

        private ProWorldzContext Context;
        private bool _dispose;

        public UnitOfWork()
        {
            Context = new ProWorldzContext();
            _dispose = false;
        }

        
        private IRepository<User> userRepository;
        private IRepository<Country> countryRepository;
        private IRepository<City> cityRepository;
        private IRepository<State> stateRepository;
        private IRepository<Community> communityRepository;
        private IRepository<UserPost> userPostRepository;
        private IRepository<UserPostComment> userPostCommentRepository;
        private IRepository<UserGeneralInfomation> userGeneralInfomationRepository;
        private IRepository<UserPersonalInfomation> userPersonalInfomationRepository;
        private IRepository<UserProfessionalQualification> userProfessionalQualificationRepository;
        private IRepository<UserQualification> userQualificationRepository;
        private IRepository<UserVideo> userVideoRepository;
        private IRepository<IndustryType> industryTypeRepository;
        private IRepository<Degree> degreeRepository;
        private IRepository<ContactUs> contactUs;
        private IRepository<Friend> friendRepository { get; set; }

        private IRepository<LatestTechnology> latestTechnologyRepository { get; set; }
        private IRepository<LatestTutorials> latestTutorialsRepository { get; set; }

        private IRepository<MasterContent> masterContentRepository { get; set; }
        private IRepository<MasterFilePath> masterFilePathRepository { get; set; }
        private IRepository<MasterUrl> masterUrlRepository { get; set; }

        private IRepository<UserResume> userResumeRepository { get; set; }
        private IRepository<MasterModuleTypeData> masterModuleTypeDataRepository { get; set; }

        private IRepository<Employer> employerRepository { get; set; }

        private IRepository<Job> jobRepository { get; set; }

        private IRepository<UserBlock> userBlockRepository { get; set; }

        private IRepository<ShareContactDetail> shareContactDetailRepository { get; set; }

        public IRepository<UserBlock> UserBlockRepository
        {
            get
            {
                if (userBlockRepository == null)
                    userBlockRepository = new GenericRepository<UserBlock>(Context);
                return userBlockRepository;
            }
        }

        public IRepository<ShareContactDetail> ShareContactDetailRepository
        {
            get
            {
                if (shareContactDetailRepository == null)
                    shareContactDetailRepository = new GenericRepository<ShareContactDetail>(Context);
                return shareContactDetailRepository;
            }
        }

        public IRepository<Job> JobRepository
        {
            get
            {
                if (jobRepository == null)
                    jobRepository = new GenericRepository<Job>(Context);
                return jobRepository;
            }
        }



        public IRepository<Employer> EmployerRepository
        {
            get
            {
                if (employerRepository == null)
                    employerRepository = new GenericRepository<Employer>(Context);
                return employerRepository;
            }
        }

        public IRepository<UserResume> UserResumeRepository
        {
            get
            {
                if (userResumeRepository == null)
                    userResumeRepository = new GenericRepository<UserResume>(Context);
                return userResumeRepository;
            }
        }
        public IRepository<MasterModuleTypeData> MasterModuleTypeDataRepository
        {
            get
            {
                if (masterModuleTypeDataRepository == null)
                    masterModuleTypeDataRepository = new GenericRepository<MasterModuleTypeData>(Context);
                return masterModuleTypeDataRepository;
            }
        }
        public IRepository<MasterContent> MasterContentRepository
        {
            get
            {
                if (masterContentRepository == null)
                    masterContentRepository = new GenericRepository<MasterContent>(Context);
                return masterContentRepository;
            }
        }
        public IRepository<MasterFilePath> MasterFilePathRepository
        {
            get
            {
                if (masterFilePathRepository == null)
                    masterFilePathRepository = new GenericRepository<MasterFilePath>(Context);
                return masterFilePathRepository;
            }
        }

        public IRepository<MasterUrl> MasterUrlRepository
        {
            get
            {
                if (masterUrlRepository == null)
                    masterUrlRepository = new GenericRepository<MasterUrl>(Context);
                return masterUrlRepository;
            }
        }


        public IRepository<LatestTutorials> LatestTutorialsRepository
        {
            get
            {
                if (latestTutorialsRepository == null)
                    latestTutorialsRepository = new GenericRepository<LatestTutorials>(Context);
                return latestTutorialsRepository;
            }
        }

        public IRepository<LatestTechnology> LatestTechnologyRepository
        {
            get
            {
                if (latestTechnologyRepository == null)
                    latestTechnologyRepository = new GenericRepository<LatestTechnology>(Context);
                return latestTechnologyRepository;
            }
        }
        public IRepository<Degree> DegreeRepository
        {
            get
            {
                if (degreeRepository == null)
                    degreeRepository = new GenericRepository<Degree>(Context);
                return degreeRepository;
            }
        }
        public IRepository<ContactUs> ContactUsRepository
        {
            get
            {
                if (contactUs == null)
                    contactUs = new GenericRepository<ContactUs>(Context);
                return contactUs;
            }
        }
        public IRepository<IndustryType> IndustryTypeRepository
        {
            get
            {
                if (industryTypeRepository == null)
                    industryTypeRepository = new GenericRepository<IndustryType>(Context);
                return industryTypeRepository;
            }
        }
        public IRepository<UserPost> UserPostRepository
        {
            get
            {
                if (userPostRepository == null)
                    userPostRepository = new GenericRepository<UserPost>(Context);
                return userPostRepository;
            }
        }
        public IRepository<UserVideo> UserVideoRepository
        {
            get
            {
                if (userVideoRepository == null)
                    userVideoRepository = new GenericRepository<UserVideo>(Context);
                return userVideoRepository;
            }
        }
        public IRepository<UserPostComment> UserPostCommentRepository
        {
            get
            {
                if (userPostCommentRepository == null)
                    userPostCommentRepository = new GenericRepository<UserPostComment>(Context);
                return userPostCommentRepository;
            }
        }
        public IRepository<UserGeneralInfomation> UserGeneralInfomationRepository
        {
            get
            {
                if (userGeneralInfomationRepository == null)
                    userGeneralInfomationRepository = new GenericRepository<UserGeneralInfomation>(Context);
                return userGeneralInfomationRepository;
            }
        }
        public IRepository<UserPersonalInfomation> UserPersonalInfomationRepository
        {
            get
            {
                if (userPersonalInfomationRepository == null)
                    userPersonalInfomationRepository = new GenericRepository<UserPersonalInfomation>(Context);
                return userPersonalInfomationRepository;
            }
        }
        public IRepository<UserProfessionalQualification> UserProfessionalQualificationRepository
        {
            get
            {
                if (userProfessionalQualificationRepository == null)
                    userProfessionalQualificationRepository = new GenericRepository<UserProfessionalQualification>(Context);
                return userProfessionalQualificationRepository;
            }
        }
        public IRepository<UserQualification> UserQualificationRepository
        {
            get
            {
                if (userQualificationRepository == null)
                    userQualificationRepository = new GenericRepository<UserQualification>(Context);
                return userQualificationRepository;
            }
        }
        public IRepository<City> CityRepository
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new GenericRepository<City>(Context);
                return cityRepository;
            }
        }
        public IRepository<State> StateRepository
        {
            get
            {
                if (stateRepository == null)
                    stateRepository = new GenericRepository<State>(Context);
                return stateRepository;
            }
        }
        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new GenericRepository<User>(Context);
                return userRepository;
            }
        }
        public IRepository<Country> CountryRepository
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new GenericRepository<Country>(Context);
                return countryRepository;
            }
        }
        public IRepository<Community> CommunityRepository
        {
            get
            {
                if (communityRepository == null)
                    communityRepository = new GenericRepository<Community>(Context);
                return communityRepository;
            }
        }
        public IRepository<Friend> FriendRepository
        {
            get
            {
                if (friendRepository == null)
                    friendRepository = new GenericRepository<Friend>(Context);
                return friendRepository;
            }
        }

        

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_dispose)
            {

                if (disposing)
                {
                    Context.Dispose();
                }

            }
            _dispose = true;
        }
     
    }
}
