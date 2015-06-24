using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
  public  class UserProfessionalQualification:BaseClass
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

         public string CompanyName { get; set; }

         public DateTime StartDate { get; set; }

         public DateTime EndDate { get; set; }

         public int Designation { get; set; }

         public Decimal Salary { get; set; }

         public bool IsCurrentEmployee { get; set; }

            [ForeignKey("IndustryType")]
            public int CurrentIndustry { get; set; }

          public string UserRole { get; set; }

          public string Skill { get; set; }

         
         
         public virtual User User { get; set; }

         public virtual IndustryType IndustryType { get; set; }

       
    }
}
