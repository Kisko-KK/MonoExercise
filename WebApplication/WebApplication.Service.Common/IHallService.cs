using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;

namespace WebApplication.Service.Common
{
    public interface IHallService
    {
        List<Hall> Get();
        Hall Get(Guid id);
        int Post(Hall hall);
        int Put(Guid id, Hall hall);
        int Delete(Guid id);
    }
}
