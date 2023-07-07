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
        public async Task<List<Hall>> GetAsync()
        {
            return await hallsRepository.GetAsync();
        }

        public async Task<Hall> GetAsync(Guid id) {
            return await hallsRepository.GetAsync(id);
        }

        public async Task<int> PostAsync(Hall hall)
        {
            return await hallsRepository.PostAsync(hall);
        }

        public async Task<int> PutAsync(Guid id, Hall hall) { 
            return await hallsRepository.PutAsync(id, hall);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await hallsRepository.DeleteAsync(id);
        }
    }
}
