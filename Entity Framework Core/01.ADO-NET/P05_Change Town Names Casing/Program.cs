using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace P05_Change_Town_Names_Casing
{
    class Program
    {
        private const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var countryName = Console.ReadLine();

            try
            {
                var countryId = FindCountryId(connection, countryName);
                NoTownException(countryId);

                var affected = UpdateTowns(connection, countryName);
                NoTownException(affected);

                var towns = SelectTownNames(connection, countryName);

                PrintTowns(towns, affected);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void NoTownException(int? id)
        {
            if (id == null)
            {
                throw new InvalidOperationException("No town names were affected.");
            }
        }

        private static void PrintTowns(SqlDataReader towns, int affected)
        {
            var result = new List<string>();

            while (towns.Read())
            {
                var name = (string)towns[0];
                result.Add(name);
            }

            Console.WriteLine($"{affected} town names were affected. ");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static SqlDataReader SelectTownNames(SqlConnection connection, string countryName)
        {
            using var townNamesCommand = new SqlCommand(@"SELECT t.Name 
                FROM Towns as t
                JOIN Countries AS c ON c.Id = t.CountryCode
                WHERE c.Name = @countryName", connection);
            townNamesCommand.Parameters.AddWithValue("@countryName", countryName);

            var towns = townNamesCommand.ExecuteReader();
            return towns;
        }

        private static int UpdateTowns(SqlConnection connection, string countryName)
        {
            using var updateTownsCommand = new SqlCommand(@"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection);
            updateTownsCommand.Parameters.AddWithValue("@countryName", countryName);

            var affected = updateTownsCommand.ExecuteNonQuery();
            return affected;
        }

        private static int? FindCountryId(SqlConnection connection, string countryName)
        {
            using var countryIdCommand = new SqlCommand(@"SELECT Id 
   FROM Countries
  WHERE Name = @countryName", connection);
            countryIdCommand.Parameters.AddWithValue("@countryName", countryName);

            var countryId = (int?)countryIdCommand.ExecuteScalar();
            return countryId;
        }
    }
}
