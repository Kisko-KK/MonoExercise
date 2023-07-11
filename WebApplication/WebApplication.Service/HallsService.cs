using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;
using WebApplication.Repository;
using WebApplication.Repository.Common;
using WebApplication.Service.Common;

namespace WebApplication.Service
{
    public class HallsService : IHallService
    {
        public IHallRepository HallsRepository { get; set; }
        public HallsService(IHallRepository hallsRepository) {
            HallsRepository = hallsRepository;   
        }
        
        public async Task<List<Hall>> GetAsync()
        {
            return await HallsRepository.GetAsync();
        }

        public async Task<Hall> GetAsync(Guid id) {
            return await HallsRepository.GetAsync(id);
        }

        public async Task<int> PostAsync(Hall hall)
        {
            return await HallsRepository.PostAsync(hall);
        }

        public async Task<int> PutAsync(Guid id, Hall hall) { 
            return await HallsRepository.PutAsync(id, hall);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await HallsRepository.DeleteAsync(id);
        }

        public async Task<Hall> GetHallAsync(Guid id)
        {
            return await HallsRepository.GetHallAsync(id);
        }
    }
}
