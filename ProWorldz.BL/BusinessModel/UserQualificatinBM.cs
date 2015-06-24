using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
    public class UserQualificatinBM : BaseBM
    {

        public int Id { get; set; }


        public int UserId { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public int Degree { get; set; }
        [Required]
        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }
        [Required]
        public string Percentage { get; set; }

        public string Description { get; set; }
    }
}
