using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
    public class User : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [Required]//check unique user name
        public string Name { get; set; }
        
        [Required]//check unique user name
        public string Email { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        public int CommunityId { get; set; }

        public int SubCommunityId { get; set; }

        public int CommunityName { get; set; }

        public int SubCommunityName { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }



        [ForeignKey("State")]
        public int StateId { get; set; }

         [ForeignKey("Country")]
          public int CountryName { get; set; }

         public virtual City City { get; set; }
         public virtual Country Country { get; set; }

         public virtual State State { get; set; }

        
    }
}
