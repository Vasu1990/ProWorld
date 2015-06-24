using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
  public  class CommunityBM
    {

        public int Id { get; set; }

      
        public string Name { get; set; }

        public int ParentId { get; set; }

        public bool Active { get; set; }

      
        public System.DateTime CreationDate { get; set; }

        public Nullable<System.DateTime> ModificationDate { get; set; }

        public int CreatedBy { get; set; }

        public Nullable<int> ModifiedBy { get; set; }
    }
}
