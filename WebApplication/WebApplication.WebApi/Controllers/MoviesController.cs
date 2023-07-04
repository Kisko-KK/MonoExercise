using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.WebApi.Models;

namespace WebApplication.WebApi.Controllers
{
    public class MoviesController : ApiController
    {
        private static List<Movie> movies;
        public List<Movie> Movies
        {
            get
            {
                if (movies == null)
                {
                    movies = new List<Movie>();
                    movies.Add(new Movie(1, "Pirati s kariba", "doobar", 3.8));
                    movies.Add(new Movie(2, "Shrek", "dooooobar", 4.0));
                    movies.Add(new Movie(3, "Forest Gump", "dobar", 3.6));
                }
                return movies;
            }
        }

        // GET api/movies
        public HttpResponseMessage Get()
        {
            if (Movies.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There aren't any movies!");
            }

            List<MovieView> movieViews = Movies.Select(movie => new MovieView(movie.Id, movie.Title, movie.Description)).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, movieViews);
        }


        // GET api/movies/5
        public HttpResponseMessage Get(int id)
        {
            Movie foundMovie = Movies.Find(movie => IsEqual(movie.Id, id));
            

            if (foundMovie == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no movie with that id!");
            }
            MovieView movieView = new MovieView(foundMovie.Id, foundMovie.Title, foundMovie.Description);
            return Request.CreateResponse(HttpStatusCode.OK, movieView);

 
        }

        // POST api/movies
        public HttpResponseMessage Post([FromBody] CreateMovie createMovie)
        {
            int id = CreateId();
            Movie movie = new Movie(id, createMovie.Title, createMovie.Description, createMovie.Score);
            Movies.Add(movie);
            return Request.CreateResponse(HttpStatusCode.OK, Movies);

        }

        // PUT api/movies/5
        public HttpResponseMessage Put(int id, [FromBody] UpdateMovie updateMovie)
        {
            Movie foundMovie = Movies.Find(m => IsEqual(m.Id, id));
            if (foundMovie != null)
            {
                foundMovie.Score = updateMovie.Score;

                return Request.CreateResponse(HttpStatusCode.OK, foundMovie);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no Movie with that id!");
            }
        }

        // DELETE api/movies/5
        public HttpResponseMessage Delete(int id)
        {
            bool removed = Movies.Remove(Movies.Find(movie => IsEqual(movie.Id, id)));
            if (removed)
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Movie with the id {id} is deleted!");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no Movie with that id!");
            }
        }


        private bool IsEqual(int leftMovieId, int rightMovieId)
        {
            return leftMovieId == rightMovieId;
        }

        private int CreateId()
        {
            return Movies.Max(movie => movie.Id) + 1;
        }
    }
}
