using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.DL.Models
{
   public class MasterFilePath
    {
       [Key]
        public int Id { get; set; }

        public int ModuleId { get; set; }

        public string FilePath { get; set; }
    }
}
