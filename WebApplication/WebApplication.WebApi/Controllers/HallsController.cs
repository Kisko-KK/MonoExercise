using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Model;
using WebApplication.Service;
using WebApplication.WebApi.Models;
using System.Threading.Tasks;

namespace WebApplication.WebApi.Controllers
{
    public class HallsController : ApiController
    {
        private HallsService hallsService = new HallsService();

        // GET api/halls
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK,await hallsService.GetAsync());
        }

        // GET api/halls/5
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            Hall hall = await hallsService.GetAsync(id);

            if (hall == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There isn't any hall with that id!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, hall);
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody] UpdateHall updatedHall)
        {
            Guid id = Guid.NewGuid();
            Hall hall = new Hall();
            hall.Id = id;
            hall.Name = updatedHall.Name;
            hall.NumOfSeats = (int)updatedHall.NumOfSeats;

            int rowsAffected = await hallsService.PostAsync(hall);

            if (rowsAffected <= 0)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't create new hall");
            }
            return Request.CreateResponse(HttpStatusCode.OK,"Created new hall!");
        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] UpdateHall updatedHall)
        {

            Hall hall = new Hall(id, updatedHall.Name, (int)updatedHall.NumOfSeats);

            int rowsAffected = await hallsService.PutAsync(id, hall);

            if (rowsAffected == -2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hall with this id doesn't exist!");
            }

            if (rowsAffected == -3)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There are no specified parameters!");
            }
            if(rowsAffected <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't update hall");
            }

            return Request.CreateResponse(HttpStatusCode.OK, hall);
        }

        // DELETE api/<controller>/5
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            int rowsAffected = await hallsService.DeleteAsync(id);

            if(rowsAffected == -2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hall with this id doesn't exist.");
            }
            if (rowsAffected <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't delete hall!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Hall with id:{id} was deleted!");
        }



        
        }
    }
