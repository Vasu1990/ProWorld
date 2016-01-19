using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
   public class ShareContactDetailBM
    {
        public int Id { get; set; }

        public int CurrentUserId { get; set; }

        public int ShareUserId { get; set; }

        public string Message { get; set; }

        public System.DateTime CreationDate { get; set; }

        public Nullable<System.DateTime> ModificationDate { get; set; }

        public int CreatedBy { get; set; }

        public Nullable<int> ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
