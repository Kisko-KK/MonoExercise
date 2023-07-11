using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Common
{
    public class HallFilter
    {
        public HallFilter(int? minSeats, int? maxSeats, string name) {
            SearchQuery = "";
            MinSeats = minSeats;
            MaxSeats = maxSeats;
            Name = name;
        }
        public string SearchQuery { get; set; }
        public int? MinSeats { get; set; }
        public int? MaxSeats { get; set; }
        public string Name { get; set; }
    }
}
