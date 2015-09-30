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

       public int CountryId { get; set; }
       [MaxLength(100)]
       public string CompanyName { get; set; }

       public string Website { get; set; }

       public string Description { get; set; }

       public string Path { get; set; }

       public int LocationId { get; set; }

       public string CompanyExtentionNumber { get; set; }

       public string Address { get; set; }
        [MaxLength(20)]
       public int CompanyContactNumber { get; set; }
        [MaxLength(100)]
       public string Username { get; set; }

       public string Designation { get; set; }

       public bool IsDeleted { get; set; }
        [MaxLength(20)]
       public int UserPhoneNumber { get; set; }


    }
}
