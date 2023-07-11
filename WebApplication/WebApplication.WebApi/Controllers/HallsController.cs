using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Model;
using WebApplication.Service;
using WebApplication.WebApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Service.Common;
using WebApplication.Common;

namespace WebApplication.WebApi.Controllers
{
    public class HallsController : ApiController
    {
        protected IHallService HallsService { get; set; }
        public HallsController(IHallService hallsService) {
            HallsService = hallsService;
        }
        
        public async Task<HttpResponseMessage> Get(string orderBy = "Name", string sortOrder = "DESC", int pageSize = 2, int pageNumber = 1, int? minSeats = null, int? maxSeats = null, string name = "")
        {
            Sorting sorting = new Sorting(orderBy, sortOrder);
            Paging paging = new Paging(pageSize, pageNumber);
            HallFilter hallFilter = new HallFilter(minSeats, maxSeats, name);

            PagingList<Hall> pagingList = await HallsService.GetAsync(sorting, paging, hallFilter);
            List<ViewHall> viewHalls = new List<ViewHall>();
            pagingList.Results.ForEach(hall =>
            {
                ViewHall viewHall = new ViewHall(hall.Id, hall.Name, (int)hall.NumOfSeats);
                viewHalls.Add(viewHall);
            });

            return Request.CreateResponse(HttpStatusCode.OK, pagingList);
        }

        // GET api/halls/5
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            Hall hall = await HallsService.GetAsync(id);

            if (hall == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There isn't any hall with that id!");
            }

            ViewHall viewHall = new ViewHall(hall.Id, hall.Name, (int)hall.NumOfSeats);

            return Request.CreateResponse(HttpStatusCode.OK, viewHall);
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody] UpdateHall updatedHall)
        {
            Guid id = Guid.NewGuid();
            Hall hall = new Hall();
            hall.Id = id;
            hall.Name = updatedHall.Name;
            hall.NumOfSeats = (int)updatedHall.NumOfSeats;

            int rowsAffected = await HallsService.PostAsync(hall);

            if (rowsAffected <= 0)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't create new hall");
            }
            return Request.CreateResponse(HttpStatusCode.OK,"Created new hall!");
        }

        // PUT api/<controller>/5
        public async Task<HttpResponseMessage> Put(Guid id, [FromBody] UpdateHall updatedHall)
        {
            Hall existingHall = await HallsService.GetHallAsync(id);
            if (existingHall == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hall with this id doesn't exist!");
            }

            Hall hall = new Hall(id, updatedHall.Name, (int)updatedHall.NumOfSeats);

            int rowsAffected = await HallsService.PutAsync(id, hall);

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
            int rowsAffected = await HallsService.DeleteAsync(id);

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
