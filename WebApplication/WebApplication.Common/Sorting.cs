using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common
{
    public class Sorting
    {
        public Sorting(string orderBy, string sortOrder) { 
            OrderBy = orderBy;
            SortOrder = sortOrder;
        }
        public string OrderBy { get; set; }
        public string SortOrder { get; set; }
    }
}
