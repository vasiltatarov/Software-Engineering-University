using System;
using Microsoft.Data.SqlClient;

namespace P02_VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var command = new SqlCommand(@"SELECT v.Name, COUNT(*) AS Minions
                    FROM Villains AS v 
                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                GROUP BY v.Name 
                  HAVING COUNT(*) >= 2
                ORDER BY Minions", sqlConnection);

            var data = command.ExecuteReader();

            while (data.Read())
            {
                var name = (string) data["Name"];
                var minionsCount = (int) data["Minions"];

                Console.WriteLine($"{name} - {minionsCount}");
            }

            //Example: How many Employees has in SoftUni DB - read Scalar

            //var connectionString = "Server=.;Database=SoftUni;Integrated Security=true;";

            //using var sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();

            //var command = new SqlCommand(@"SELECT COUNT(*) FROM Employees", sqlConnection);

            //var data = (int) command.ExecuteScalar();
            //Console.WriteLine($"{0}");
        }
    }
}
