using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
  public  class UserResumeBM
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool IsVisaHolder { get; set; }

        public bool IsForeignWorker { get; set; }

        public string TotalExperience { get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public string ResumePath { get; set; }

        public string CoverLetterPath { get; set; }

        public string ResumeContent { get; set; }

        public string CoverLetterContent { get; set; }

        public List<string> Locations { get; set; }

        public List<string> Companies { get; set; }

        public List<string> Intrests { get; set; }

        public List<string> Hobbies { get; set; }
    }
}
