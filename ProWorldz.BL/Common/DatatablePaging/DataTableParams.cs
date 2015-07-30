using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.Common.DatatablePaging
{
    public class DataTableParams
    {
        public List<DataTableConfig> ColumnConfiguration { get; set; }
        public GlobalSearchText SearchOptions { get; set; }
        public int RecordsToTake { get; set;}
        public int RecordsToSkip { get; set; }
            
    }
}
