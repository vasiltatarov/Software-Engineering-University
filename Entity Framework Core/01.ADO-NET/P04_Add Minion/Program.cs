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

            var minionData = Console.ReadLine().Split();
            var minionName = minionData[1];
            var age = int.Parse(minionData[2]);
            var townName = minionData[3];

            var villainData = Console.ReadLine().Split();
            var villainName = villainData[1];

            var villainId = VillainIdCommand(connection, villainName);
            //If villainId is null - add it to db.
            if (villainId == null)
            {
                var insertedVillain = InsertVillainCommand(connection, villainName);

                if (insertedVillain != 0)
                {
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }
            }

            var townId = TownIdCommand(connection, townName);
            //If town does not exist - add it to db.
            if (townId == null)
            {
                var insertedTown = InsertTownCommand(connection, townName);

                if (insertedTown != 0)
                {
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
            }

            var minionId = MinionIdCommand(connection, minionName);
            if (minionId == null)
            { 
                townId = TownIdCommand(connection, townName);

                InsertMinionCommand(connection, minionName, age, townId);
            }

            villainId = VillainIdCommand(connection, villainName);
            minionId = MinionIdCommand(connection, minionName);

            var inserted = InsertMinionVillainCommand(connection, villainId, minionId);
            if (inserted != 0)
            {
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static int InsertMinionVillainCommand(SqlConnection connection, int? villainId, int? minionId)
        {
            var insertMinionsVillainsCommand = new SqlCommand
                ("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", connection);
            insertMinionsVillainsCommand.Parameters.AddWithValue(@"minionId", minionId);
            insertMinionsVillainsCommand.Parameters.AddWithValue(@"villainId", villainId);

            var inserted = insertMinionsVillainsCommand.ExecuteNonQuery();
            return inserted;
        }

        private static void InsertMinionCommand(SqlConnection connection, string minionName, int age, int? townId)
        {
            var insertMinionCommand = new SqlCommand
                ("INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)", connection);
            insertMinionCommand.Parameters.AddWithValue("@nam", minionName);
            insertMinionCommand.Parameters.AddWithValue("@age", age);
            insertMinionCommand.Parameters.AddWithValue("@townId", townId);

            var inserted = insertMinionCommand.ExecuteNonQuery();
        }

        private static int? MinionIdCommand(SqlConnection connection, string minionName)
        {
            var minionCommand = new SqlCommand("SELECT Id FROM Minions WHERE Name = @Name", connection);
            minionCommand.Parameters.AddWithValue("@Name", minionName);

            var minionId = (int?) minionCommand.ExecuteScalar();
            return minionId;
        }

        private static int InsertTownCommand(SqlConnection connection, string townName)
        {
            var insertTownCommand = new SqlCommand("INSERT INTO Towns (Name) VALUES (@townName)", connection);
            insertTownCommand.Parameters.AddWithValue("@townName", townName);

            var inserted = insertTownCommand.ExecuteNonQuery();
            return inserted;
        }

        private static int? TownIdCommand(SqlConnection connection, string townName)
        {
            var findTownCommand = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", connection);
            findTownCommand.Parameters.AddWithValue(@"townName", townName);

            var townId = (int?) findTownCommand.ExecuteScalar();
            return townId;
        }

        private static int InsertVillainCommand(SqlConnection connection, string villainName)
        {
            var insertVillainCommand = new SqlCommand
                ("INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", connection);
            insertVillainCommand.Parameters.AddWithValue("villainName", villainName);

            var inserted = insertVillainCommand.ExecuteNonQuery();
            return inserted;
        }

        private static int? VillainIdCommand(SqlConnection connection, string villainName)
        {
            var villainCommand = new SqlCommand("SELECT Id FROM Villains WHERE Name = @Name", connection);
            villainCommand.Parameters.AddWithValue("@Name", villainName);

            var villainId = (int?)villainCommand.ExecuteScalar();
            return villainId;
        }
    }
}
