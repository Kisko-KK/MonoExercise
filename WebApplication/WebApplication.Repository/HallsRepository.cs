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

        public async Task<List<Hall>> GetAsync()
        {
            List<Hall> halls = new List<Hall>();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM hall", connection);
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

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


        public async Task<Hall> GetAsync(Guid id)
        {
            return await GetHallAsync(id);
        }


        public async Task<int> PostAsync(Hall hall)
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string commandText = $"INSERT INTO Hall (Id, Name, NumOfSeats) VALUES (@id, @name, @numOfSeats)";

                NpgsqlCommand command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("id", hall.Id);
                command.Parameters.AddWithValue("name", hall.Name);
                command.Parameters.AddWithValue("numOfSeats", hall.NumOfSeats);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected;
            }

        }

        public async Task<int> PutAsync(Guid id, Hall hall)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                bool hasParameters = false;

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;

                StringBuilder commandQueryBuilder = new StringBuilder("UPDATE Hall SET");

                if (!string.IsNullOrEmpty(hall.Name))
                {
                    commandQueryBuilder.Append(" Name = @name,");
                    command.Parameters.AddWithValue("@name", hall.Name);
                    hasParameters = true;
                }
                if (hall.NumOfSeats != null)
                {
                    commandQueryBuilder.Append(" NumOfSeats = @numOfSeats,");
                    command.Parameters.AddWithValue("@numOfSeats", hall.NumOfSeats);
                    hasParameters = true;
                }
                if (hasParameters)
                {
                    // Remove the trailing comma
                    commandQueryBuilder.Length -= 1;
                    commandQueryBuilder.Append(" WHERE Id = @id");
                }
                else
                {
                    return -3; // no specified parameters
                }

                command.CommandText = commandQueryBuilder.ToString();
                command.Parameters.AddWithValue("@id", id);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected;
            }
        }


        public async Task<int> DeleteAsync(Guid id)
        {
            Hall hall =await  GetHallAsync(id);

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

                int rowsAffected =await command.ExecuteNonQueryAsync();

                return rowsAffected;
            }
        }



        public async Task<Hall> GetHallAsync(Guid id)
        {
            Hall hall = new Hall();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM hall WHERE id = @Id", connection);
                    command.Parameters.AddWithValue("Id", id);
                    NpgsqlDataReader reader = await command.ExecuteReaderAsync();

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
