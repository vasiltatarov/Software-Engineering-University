using System;
using Microsoft.Data.SqlClient;

namespace P03_MinionNames
{
    /// <summary>
    /// connectionString
    /// 
    ///- SqlConnection
    ///- openSqlConnection
    ///- ExecuteNonQuery
    ///- Insert, Delete ,Update
    /// 
    ///- ExecuteScalar
    ///- If the select query returns only one record
    /// 
    ///- ExecuteReader
    ///- If the select query returns more than one record
    /// 
    ///command.Parameters.AddWithValue("@villainId", villainId);
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var villainId = int.Parse(Console.ReadLine());

            var isVillainExistCommand =
                new SqlCommand($@"SELECT Name FROM Villains WHERE Id = @villainId", sqlConnection);

            isVillainExistCommand.Parameters.AddWithValue("@villainId", villainId);
            var villainName = isVillainExistCommand.ExecuteScalar() as string;

            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }
            else
            {
                Console.WriteLine($"Villain: {villainName}");
            }

            var villainMinionsCommand = new SqlCommand($@"SELECT v.Name AS Villain, m.Name AS Minion, m.Age AS Age
FROM Villains AS v
JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
JOIN Minions AS m ON m.Id = mv.MinionId
WHERE v.Id = @villainId
ORDER BY m.Name ASC", sqlConnection);

            villainMinionsCommand.Parameters.AddWithValue("@villainId", villainId);
            var minions = villainMinionsCommand.ExecuteReader();

            if (!minions.HasRows)
            {
                Console.WriteLine($"(no minions)");
                return;
            }

            var counter = 1;
            while (minions.Read())
            {
                var name = (string) minions["Minion"];
                var age = (int) minions["Age"];

                Console.WriteLine($"{counter++}. {name} {age}");
            }
        }
    }
}
