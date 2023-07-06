using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.WebApi.Models;

namespace WebApplication.WebApi.Controllers
{
    public class MoviesController : ApiController
    {
        
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        // GET api/movies
        public HttpResponseMessage Get()
        {
            List<Movie> movies = new List<Movie>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM movie", connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Movie movie = new Movie();
                    movie.Id = (Guid)reader["Id"];
                    movie.Name = (string)reader["Name"];
                    movie.Duration = (int)reader["Duration"];
                    movie.Score = (double)reader["Score"]; 
                    movies.Add(movie);
                }
                reader.Close();
            }

            return Request.CreateResponse(HttpStatusCode.OK, movies);

            
        }


        // GET api/movies/5
        /*
        public HttpResponseMessage Get(int id)
        {
            

 
        }
     
        // POST api/movies
    
        public HttpResponseMessage Post([FromBody] CreateMovie createMovie)
        {
            

        }

        // PUT api/movies/5
        public HttpResponseMessage Put(int id, [FromBody] UpdateMovie updateMovie)
        {
            
        }

        // DELETE api/movies/5
        public HttpResponseMessage Delete(int id)
        {
            
        }

        */
 
    }
}
