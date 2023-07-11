using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common;
using WebApplication.Model;

namespace WebApplication.Service.Common
{
    public interface IHallService
    {
        Task<PagingList<Hall>> GetAsync(Sorting sorting, Paging paging, HallFilter hallFilter);
        Task<Hall> GetAsync(Guid id);
        Task<int> PostAsync(Hall hall);
        Task<int> PutAsync(Guid id, Hall hall);
        Task<int> DeleteAsync(Guid id);
        Task<Hall> GetHallAsync(Guid id);
    }
}
