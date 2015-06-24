using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
    public class UserGeneralInformationBM : BaseBM
    {
        
        public int Id { get; set; }
       
        public int CommunityId { get; set; }

        public bool Active { get; set; }
        
        public int UserId { get; set; }

        public int SubCommunityId { get; set; }

        public string Image { get; set; }

        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
