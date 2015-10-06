using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class Employer:BaseClass
    {
       [Key]
       public int Id { get; set; }
       [Required]
       public string Email { get; set; }

       public string Password { get; set; }

       public Nullable<int> CountryId { get; set; }
       [MaxLength(100)]
       public string CompanyName { get; set; }

       public string Website { get; set; }

       public string Description { get; set; }

       public string Path { get; set; }

       public Nullable<int> LocationId { get; set; }


       public Nullable<int> IndustryId { get; set; }

       public string CompanyExtentionNumber { get; set; }

       public string Address { get; set; }

       public Nullable<int> CompanyContactNumber { get; set; }
        [MaxLength(100)]
       public string Username { get; set; }

       public string Designation { get; set; }



       public Nullable<int> UserPhoneNumber { get; set; }


    }
}
