using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserVideo : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string VideoResumeUrl { get; set; }

        public string ArtWorkYouTube1 { get; set; }
        public string ArtWorkYouTube2 { get; set; }
        public string ArtWorkYouTube3 { get; set; }
        public string ArtWorkYouTube4 { get; set; }
        public string ArtWorkYouTube5 { get; set; }

        public string ArtWorkUrl1 { get; set; }
        public string ArtWorkUrl2 { get; set; }
        public string ArtWorkUrl3 { get; set; }
        public virtual User User { get; set; }
    }
}
