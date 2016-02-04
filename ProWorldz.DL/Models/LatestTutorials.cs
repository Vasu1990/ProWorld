using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class LatestTutorials
    {
        [Key]
        public int Id { get; set; }

        public int CommunityId { get; set; }

        public int SubCommunityId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Subject { get; set; }

        public string Tag { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public string VideoUrl { get; set; }

        public string FilePath { get; set; }

        public int EarnPoint { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
