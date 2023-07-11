using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;

namespace WebApplication.Common
{
    public class PagingList<T>
    {
        public PagingList(int pageSize, int pageNumber)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalResultNumber { get; set; }
        public List<T> Results { get; set; }
    }
}
