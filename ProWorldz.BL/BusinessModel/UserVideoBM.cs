using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
    public class UserVideoBM : BaseBM
    {
        public int Id { get; set; }

        
        public int UserId { get; set; }
        [Required]
        public string VideoResumeUrl { get; set; }
        [Required]
        public string ArtWorkYouTube1 { get; set; }
        public string ArtWorkYouTube2 { get; set; }
        public string ArtWorkYouTube3 { get; set; }
        public string ArtWorkYouTube4 { get; set; }
        public string ArtWorkYouTube5 { get; set; }
        [Required]
        public string ArtWorkUrl1 { get; set; }
        public string ArtWorkUrl2 { get; set; }
        public string ArtWorkUrl3 { get; set; }
    }
}
