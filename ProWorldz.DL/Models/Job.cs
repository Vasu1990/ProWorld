using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
  public  class Job : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int EmployerId { get; set; }

        [MaxLength(200)]
        public string Headline { get; set; }



        public string JobRole { get; set; }

        public string JobSkill { get; set; }

        public string JobFunction { get; set; }

        public Nullable<int> CountryId { get; set; }

        public Nullable<int> StateId { get; set; }

        public Nullable<int> CityId { get; set; }

        public Nullable<int> CommunityId { get; set; }

        public Nullable<int> SubCommunityId { get; set; }

        public string EducationQualificaation { get; set; }

        public string ExpYear { get; set; }

        public string ExpMonth { get; set; }

        public Nullable<int> IndustryId { get; set; }

        public string SalaryLakhs { get; set; }

        public string SalaryMonths { get; set; }

        public string JobDescription { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DateOfAdvExp { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }

        public string EmployementType { get; set; }

        

        
    }
}
