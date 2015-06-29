using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessModel
{
   public  class PostBM
    {
        
        public int Id { get; set; }

        public string Message { get; set; }
        
        public int PostedBy { get; set; }

        public DateTime PostedDate { get; set; }

        public virtual UserBM User { get; set; }
    }
}
