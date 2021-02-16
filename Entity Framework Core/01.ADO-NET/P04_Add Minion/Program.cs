using System;
using Microsoft.Data.SqlClient;

namespace P04_Add_Minion
{
    class Program
    {
        public const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT * FROM Minions", connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }
    }
}
