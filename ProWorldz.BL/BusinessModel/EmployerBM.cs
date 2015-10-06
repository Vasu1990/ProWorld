using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
   public class EmployerBM
    {
        public int Id { get; set; }
      
        public string Email { get; set; }

        public string Password { get; set; }

        public Nullable<int> CountryId { get; set; }
      
        public string CompanyName { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public Nullable<int> LocationId { get; set; }

        public Nullable<int> IndustryId { get; set; }

        public string CompanyExtentionNumber { get; set; }

        public string Address { get; set; }

        public Nullable<int> CompanyContactNumber { get; set; }
     
        public string Username { get; set; }

        public string Designation { get; set; }



        public Nullable<int> UserPhoneNumber { get; set; }

        public bool Active { get; set; }

    
        public System.DateTime CreationDate { get; set; }

        public Nullable<System.DateTime> ModificationDate { get; set; }

        public int CreatedBy { get; set; }

        public Nullable<int> ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }


    }
}
