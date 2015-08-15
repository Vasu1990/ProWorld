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

        public string CommunityName { get; set; }

        public string SubCommunityName { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

         [ForeignKey("Country")]
          public int CountryId { get; set; }

         public virtual City City { get; set; }
         public virtual Country Country { get; set; }

         public virtual State State { get; set; }

         public bool IsOnline { get; set; }
         //problem o multiplicity  Multiplicity is not valid in Role 'UserGeneralInfomation_User_Source' in relationship 'UserGeneralInfomation_User'. 
        //Because the Dependent Role properties are not the key properties, the upper bound of the multiplicity of the Dependent Role must be '*'
        //http://stackoverflow.com/questions/26386831/one-fk-works-another-gives-error-multiplicity-is-not-valid
        //public virtual UserGeneralInfomation UserGeneralInfo { get; set; } 

         //temp soln http://stackoverflow.com/questions/26386831/one-fk-works-another-gives-error-multiplicity-is-not-valid or use fluent api
        public virtual ICollection<UserGeneralInfomation> UserGeneralInfo { get; set; }
        public virtual ICollection<Friend> UserFriends { get; set; }
        
    }
}
