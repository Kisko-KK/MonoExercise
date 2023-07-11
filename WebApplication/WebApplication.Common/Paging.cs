using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common
{
    public class Paging
    {
        public Paging(int pageSize, int pageNumber) { 
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
