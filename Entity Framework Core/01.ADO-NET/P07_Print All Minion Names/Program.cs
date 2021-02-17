using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace P07_Print_All_Minion_Names
{
    class Program
    {
        private const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var selectMinionsCommand = new SqlCommand(@"SELECT Name FROM Minions", connection);

            var minions = selectMinionsCommand.ExecuteReader();

            var result = new List<string>();

            while (minions.Read())
            {
                var name = (string)minions[0];
                result.Add(name);
            }

            for (int i = 0; i < result.Count / 2; i++)
            {
                Console.WriteLine(result[i]);
                Console.WriteLine(result[result.Count - 1 - i]);
            }

            if (result.Count % 2 != 0)
            {
                Console.WriteLine(result[result.Count / 2]);
            }
        }
    }
}
