using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProWorldz.Web.Areas.Employer.Models
{
    public class JobModel
    {
        public JobBM Job { get; set; }
        public List<CountryBM> CountryList { get; set; }
        public List<StateBM> StateList { get; set; }
        public List<CityBM> CityList { get; set; }

        public List<IndustryBM> IndustryList { get; set; }

        public List<CommunityBM> CommunityList { get; set; }
        public List<CommunityBM> SubCommunityList { get; set; }

        CommonBL commonBL = new CommonBL();
        StateBL stateBL = new StateBL();
        CountryBL countryBL = new CountryBL();
        CityBL cityBL = new CityBL();
        CommunityBL communityBL = new CommunityBL();
        public JobModel()
        {
            this.Job = new JobBM();
            CountryList = countryBL.GetCountry();
            StateList = stateBL.GetState();
            CityList = cityBL.GetCities();
            CommunityList = communityBL.GetCommunity().Where(p => p.ParentId == 0).ToList(); 
            SubCommunityList = communityBL.GetCommunity().Where(p => p.ParentId != 0).ToList();
           IndustryList= commonBL.GetIndustry();
        }
    }
}