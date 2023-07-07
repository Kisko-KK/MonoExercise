using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Model.Common
{
    public interface IHall
    {
        Guid Id { get; set; }
        string Name { get; set; }
        int? NumOfSeats { get; set; }
    }
}
