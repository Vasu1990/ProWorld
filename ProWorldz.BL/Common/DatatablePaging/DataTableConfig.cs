using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.Common.DatatablePaging
{
    public class DataTableConfig
    {
        public string ColumnName { get; set; }
        public bool IsSorted { get; set; }
        public string SearchText { get; set; }
        public bool IsSearchable { get; set; }
        public string SortDirection { get; set; }
    }
}
