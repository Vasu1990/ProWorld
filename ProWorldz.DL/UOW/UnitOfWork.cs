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
