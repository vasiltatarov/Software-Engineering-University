using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace P08_Increase_Minion_Age
{
    class Program
    {
        private const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            UpdateMinions(minionIds, connection);

            var minions = SelectMinions(connection);

            PrintMinions(minions);
        }

        private static void PrintMinions(SqlDataReader minions)
        {
            while (minions.Read())
            {
                var name = (string) minions[0];
                var age = (int) minions[1];

                Console.WriteLine($"{name} {age}");
            }
        }

        private static SqlDataReader SelectMinions(SqlConnection connection)
        {
            using var selectMinionsCommand = new SqlCommand(@"SELECT Name, Age FROM Minions", connection);

            var minions = selectMinionsCommand.ExecuteReader();
            return minions;
        }

        private static void UpdateMinions(int[] minionIds, SqlConnection connection)
        {
            for (int i = 0; i < minionIds.Length; i++)
            {
                var id = minionIds[i];

                var updateMinionCommand = new SqlCommand(@" UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id", connection);
                updateMinionCommand.Parameters.AddWithValue("@Id", id);

                updateMinionCommand.ExecuteNonQuery();
            }
        }
    }
}
