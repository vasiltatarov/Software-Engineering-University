using System;
using Microsoft.Data.SqlClient;

namespace P06_Remove_Villain
{
    class Program
    {
        private const string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            var villainId = int.Parse(Console.ReadLine());

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                var villainName = FindVillainNameCommand(connection, villainId);
                if (villainName == null)
                {
                    throw new InvalidOperationException("No such villain was found.");
                }

                var deletedMinionsVillains = DeleteMinionsVillainsCommand(connection, villainId);

                DeleteVillainCommand(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{deletedMinionsVillains} minions were released.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void DeleteVillainCommand(SqlConnection connection, int villainId)
        {
            var deleteVillainCommand = new SqlCommand(@"DELETE FROM Villains
      WHERE Id = @villainId", connection);
            deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);

            deleteVillainCommand.ExecuteNonQuery();
        }

        private static int DeleteMinionsVillainsCommand(SqlConnection connection, int villainId)
        {
            var deleteFromMinionsVillainsCommand = new SqlCommand(@"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId", connection);
            deleteFromMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);

            var deletedMinionsVillains = deleteFromMinionsVillainsCommand.ExecuteNonQuery();
            return deletedMinionsVillains;
        }

        private static string FindVillainNameCommand(SqlConnection connection, int villainId)
        {
            var villainIdCommand = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @villainId", connection);
            villainIdCommand.Parameters.AddWithValue(@"villainId", villainId);

            var villainName = (string) villainIdCommand.ExecuteScalar();
            return villainName;
        }
    }
}
