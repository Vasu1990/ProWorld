using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
   public class LatestTechnologyBM
    {
        public int Id { get; set; }

        public int CommunityId { get; set; }

        public int SubCommunityId { get; set; }

        public int UserId { get; set; }

        public string Subject { get; set; }

        public string Tag { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public string VideoUrl { get; set; }

        public string FilePath { get; set; }

        public bool IsActive { get; set; }
    }
}
