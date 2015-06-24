using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
    public class UserBM
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int UserTypeId { get; set; }

        public DateTime DOB { get; set; }


        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public string Gender { get; set; }

        public System.DateTime CreationDate { get; set; }

        public Nullable<System.DateTime> ModificationDate { get; set; }

        public int CreatedBy { get; set; }

        public Nullable<int> ModifiedBy { get; set; }


        public int CommunityId { get; set; }

        public int SubCommunityId { get; set; }

        public int CommunityName { get; set; }

        public int SubCommunityName { get; set; }


      
        public int CityId { get; set; }



       
        public int StateId { get; set; }

        
        public int CountryId { get; set; }
    }
}
