using System;
using Microsoft.Data.SqlClient;

namespace P09_Increase_Age_Stored_Procedure
{
    class Program
    {
        private const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var minionId = int.Parse(Console.ReadLine());

            IncreaseMinionAgeCommand(connection, minionId);

            var minion = SelectMinion(connection, minionId);
            if (!minion.HasRows)
            {
                Console.WriteLine("Minion with this id does not exist!");
                return;
            }

            PrintMinion(minion);
        }

        private static void PrintMinion(SqlDataReader minion)
        {
            while (minion.Read())
            {
                var name = (string) minion[0];
                var age = (int) minion[1];

                Console.WriteLine($"{name} – {age} years old");
            }
        }

        private static void IncreaseMinionAgeCommand(SqlConnection connection, int minionId)
        {
            using var increaseMinionAgeProcedure = new SqlCommand("EXEC usp_GetOlder @Id", connection);
            increaseMinionAgeProcedure.Parameters.AddWithValue("@Id", minionId);

            increaseMinionAgeProcedure.ExecuteNonQuery();
        }

        private static SqlDataReader SelectMinion(SqlConnection connection, int minionId)
        {
            using var minionCommand = new SqlCommand(@"SELECT Name, Age FROM Minions WHERE Id = @Id", connection);
            minionCommand.Parameters.AddWithValue(@"Id", minionId);

            var minion = minionCommand.ExecuteReader();
            return minion;
        }
    }
}
