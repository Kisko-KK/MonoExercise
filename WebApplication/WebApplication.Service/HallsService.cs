using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;
using WebApplication.Repository;
using WebApplication.Service.Common;

namespace WebApplication.Service
{
    public class HallsService : IHallService
    {
        private HallsRepository hallsRepository = new HallsRepository();
        public List<Hall> Get()
        {
            return hallsRepository.Get();
        }

        public Hall Get(Guid id) {
            return hallsRepository.Get(id);
        }

        public int Post(Hall hall)
        {
            return hallsRepository.Post(hall);
        }

        public int Put(Guid id, Hall hall) { 
            return hallsRepository.Put(id, hall);
        }

        public int Delete(Guid id)
        {
            return hallsRepository.Delete(id);
        }
    }
}
