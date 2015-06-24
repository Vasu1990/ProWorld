using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
    public class UserProfessionalQualificationBM : BaseBM
    {

        public int Id { get; set; }

        public int UserId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public int Designation { get; set; }
        [Required]
        public Decimal Salary { get; set; }
        [Required]
        public int IndustryTypeId { get; set; }

        public bool IsCurrentEmployee { get; set; }

        public string UserRole { get; set; }

        public string Skill { get; set; }

        public UserProfessionalQualificationBM()
        {
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;

        }

    }
}
