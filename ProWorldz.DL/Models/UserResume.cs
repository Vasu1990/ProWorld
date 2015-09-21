using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserResume
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]//check unique user name
        public int UserId { get; set; }

        public bool IsVisaHolder { get; set; }

        public bool IsForeignWorker { get; set; }

        public string TotalExperience { get; set; }

        public string ResumePath { get; set; }

        public string CoverLetterPath { get; set; }

        public string ResumeContent { get; set; }
        
        public string CoverLetterContent { get; set; }

        public virtual User User { get; set; }
    }
}
