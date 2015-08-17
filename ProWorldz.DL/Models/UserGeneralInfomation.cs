using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class UserGeneralInfomation:BaseClass
    {
       [Key]
        public int Id { get; set; }
       //[ForeignKey("Community")]
       //public int CommunityId { get; set; }

       public string Address1 { get; set; }

       public string Address2 { get; set; }

       public string Status { get; set; }

       public string FatherName { get; set; }



       public string PhoneNumber { get; set; }

       [ForeignKey("User")]
       public int UserId { get; set; }

     //  public int SubCommunityId { get; set; }

       public string Image { get; set; }

       public virtual User User { get; set; }

       //public virtual Community Community { get; set; }
    }
}
