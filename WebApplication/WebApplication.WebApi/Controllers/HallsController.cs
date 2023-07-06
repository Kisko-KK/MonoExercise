using Microsoft.Ajax.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApplication.WebApi.Models;

namespace WebApplication.WebApi.Controllers
{
    public class HallsController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // GET api/halls
        public HttpResponseMessage Get()
        {
            List<Hall> halls = new List<Hall>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM hall", connection);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Hall hall = new Hall();
                    hall.Id = (Guid)reader["Id"];
                    hall.Name = (string)reader["Name"];
                    hall.NumOfSeats = (int)reader["NumOfSeats"];
                    halls.Add(hall);
                }
                reader.Close();
            }

            return Request.CreateResponse(HttpStatusCode.OK, halls);
        }

        // GET api/halls/5
        public HttpResponseMessage Get(Guid id)
        {
            Hall hall = GetHall(id);

            if (hall == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There isn't any hall with that id!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, hall);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] UpdateHall updateHall)
        {
            Guid id = Guid.NewGuid();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string commandText = $"INSERT INTO Hall (Id, Name, NumOfSeats) VALUES (@id, @name, @numOfSeats)";

                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", updateHall.Name);
                command.Parameters.AddWithValue("numOfSeats", updateHall.NumOfSeats);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected <= 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't create new hall");
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK,"Created new hall!");
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Guid id, [FromBody] UpdateHall updatedHall)
        {
            Hall hall = GetHall(id);

            if (hall == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hall with this id doesn't exist!");
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                bool hasParameters = false;

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;

                List<String> parameters = new List<String>();
                if (String.IsNullOrEmpty(updatedHall.Name) == false)
                {
                    parameters.Add("Name = @name");
                    command.Parameters.AddWithValue("@name", updatedHall.Name);
                    hasParameters = true;
                    hall.Name = updatedHall.Name;
                }
                if (updatedHall.NumOfSeats != null)
                {
                    parameters.Add("NumOfSeats = @numOfSeats");
                    command.Parameters.AddWithValue("@numOfSeats", updatedHall.NumOfSeats);
                    hasParameters = true;
                    hall.NumOfSeats = updatedHall.NumOfSeats.Value;
                }

                if (hasParameters)
                {
                    command.CommandText = $"UPDATE Hall SET " + String.Join(", ", parameters) + " WHERE Id = @id";
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There are no specified parameters!");
                }



                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected <= 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't update hall");
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, hall);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(Guid id)
        {

            Hall hall = GetHall(id);

            if(hall == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hall with this id doesn't exist.");
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string commandText = $"DELETE FROM Hall WHERE Id = @id";
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("id", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected <= 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't delete hall!");
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Hall with id:{id} was deleted!");

        }



        private Hall GetHall(Guid id)
        {
            Hall hall = new Hall();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM hall WHERE id = @Id", connection);
                    command.Parameters.AddWithValue("Id", id);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    hall.Id = (Guid)reader["Id"];
                    hall.Name = (string)reader["Name"];
                    hall.NumOfSeats = (int)reader["NumOfSeats"];


                    reader.Close();
                }
                return hall;
            }catch (Exception e)
            {
                return null;
            }
            
        }
    }
}