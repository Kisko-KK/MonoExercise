using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Model;
using Npgsql;
using WebApplication.Repository.Common;
using WebApplication.Common;

namespace WebApplication.Repository
{
    public class HallsRepository : IHallRepository
    {
        private string connectionString = ConnectionUtilities.ConnectionString;

        public List<Hall> Get()
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

            return halls;
        }


        public Hall Get(Guid id)
        {
            return GetHall(id);
        }


        public int Post(Hall hall)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string commandText = $"INSERT INTO Hall (Id, Name, NumOfSeats) VALUES (@id, @name, @numOfSeats)";

                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("id", hall.Id);
                command.Parameters.AddWithValue("name", hall.Name);
                command.Parameters.AddWithValue("numOfSeats", hall.NumOfSeats);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;
            }

        }

        public int Put(Guid id, Hall hall)
        {
            Hall existingHall = GetHall(id);

            if (existingHall == null)
            {
                return -2; //doesnt exist
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                bool hasParameters = false;

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;

                List<String> parameters = new List<String>();
                if (String.IsNullOrEmpty(hall.Name) == false)
                {
                    parameters.Add("Name = @name");
                    command.Parameters.AddWithValue("@name", hall.Name);
                    hasParameters = true;
                    hall.Name = hall.Name;
                }
                if (hall.NumOfSeats != null)
                {
                    parameters.Add("NumOfSeats = @numOfSeats");
                    command.Parameters.AddWithValue("@numOfSeats", hall.NumOfSeats);
                    hasParameters = true;
                    hall.NumOfSeats = hall.NumOfSeats.Value;
                }

                if (hasParameters)
                {
                    command.CommandText = $"UPDATE Hall SET " + String.Join(", ", parameters) + " WHERE Id = @id";
                }
                else
                {
                    return -3; //no specified parameters
                }



                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;
            }
            
        }


        public int Delete(Guid id)
        {
            Hall hall = GetHall(id);

            if (hall == null)
            {
                return -2;
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string commandText = $"DELETE FROM Hall WHERE Id = @id";
                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("id", id);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected;
            }
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
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
