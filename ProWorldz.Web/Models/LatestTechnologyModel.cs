using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProWorldz.Web.Models
{
    public class LatestTechnologyModel:BaseModel
    {
        public LatestTechnologyBM latestTechnologyBM { get; set; }
        CommunityBL CommunityBL = new CommunityBL();
        LatestTechnologyBL latestTechnologyBL = new LatestTechnologyBL();
        public List<LatestTechnologyBM> LatestTechnologyBMList { get; set; }

        public List<CommunityBM> CommunityList { get; set; }
        public List<CommunityBM> SubCommunityList { get; set; }

        public LatestTechnologyModel()
        {
            this.latestTechnologyBM = new LatestTechnologyBM();
            this.CommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId == 0).ToList();
            this.LatestTechnologyBMList = latestTechnologyBL.GetLatestTechnology();
            this.SubCommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId != 0).ToList();
        }
    }

    public class LatestTutorialsModel : BaseModel
    {
        public LatestTutorialsBM LatestTutorialsBM { get; set; }
        CommunityBL CommunityBL = new CommunityBL();
        LatestTutorialsBL latestTechnologyBL = new LatestTutorialsBL();
        public List<LatestTutorialsBM> LatestTutorialsBMList { get; set; }

        public List<CommunityBM> CommunityList { get; set; }
        public List<CommunityBM> SubCommunityList { get; set; }

        public LatestTutorialsModel()
        {
            this.LatestTutorialsBM = new LatestTutorialsBM();
            this.CommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId == 0).ToList();
            this.LatestTutorialsBMList = latestTechnologyBL.GetLatestTutorials();
            this.SubCommunityList = CommunityBL.GetCommunity().Where(o => o.ParentId != 0).ToList();
        }
    }
}