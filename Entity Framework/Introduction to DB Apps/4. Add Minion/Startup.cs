namespace _4.Add_Minion
{
    using System;
    using System.Data.SqlClient;

    class Startup
    {
        static void Main()
        {
            // read minion data
            Console.Write("Minion: ");
            string[] minionData = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionData[0];
            string minionAge = minionData[1];
            string minionTown = minionData[2];
            // read villain data
            Console.Write("Villain: ");
            string villainName = Console.ReadLine().Trim();

            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connection.Open();
            using (connection)
            {
                int townId = EnsureTownExists(connection, minionTown);
                int villainId = EnsureVillainExists(connection, villainName);
                AddMinion(connection, minionName, minionAge, townId, villainId, villainName);
            }
        }

        public static int EnsureTownExists(SqlConnection connection, string minionTown)
        {
            int townId = 0;
            string getTownNameCount = @"SELECT COUNT(Name) FROM Towns WHERE Name = @TownName";
            SqlCommand command = new SqlCommand(getTownNameCount, connection);
            command.Parameters.AddWithValue("@TownName", minionTown);
            int count = (int)command.ExecuteScalar();

            if (count < 1)
            {
                string addTown = @"INSERT INTO Towns(Name,CountryId) VALUES (@TownName, @CountryId)";
                command = new SqlCommand(addTown, connection);
                command.Parameters.AddWithValue("@TownName", minionTown);
                int defaultCountryId = 1;
                command.Parameters.AddWithValue("@CountryId", defaultCountryId);
                command.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            string getTownId = "SELECT Id FROM Towns WHERE Name = @Name";
            command = new SqlCommand(getTownId, connection);
            command.Parameters.AddWithValue("@Name", minionTown);
            townId = (int)command.ExecuteScalar();
            return townId;
        }

        public static int EnsureVillainExists(SqlConnection connection, string villainName)
        {
            int villainId = 0;
            string getVillainNameCount = @"SELECT COUNT(Name) FROM Villains WHERE Name = @VillainName";
            SqlCommand command = new SqlCommand(getVillainNameCount, connection);
            command.Parameters.AddWithValue("@VillainName", villainName);
            int count = (int)command.ExecuteScalar();

            if (count < 1)
            {
                string addVillain = @"INSERT INTO Villains(Name,Evilness) VALUES (@VillainName, @Evilness)";
                command = new SqlCommand(addVillain, connection);
                command.Parameters.AddWithValue("@VillainName", villainName);
                string defaultEvilness = "evil";
                command.Parameters.AddWithValue("@Evilness", defaultEvilness);
                command.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            string getVillainId = "SELECT Id FROM Villains WHERE Name = @Name";
            command = new SqlCommand(getVillainId, connection);
            command.Parameters.AddWithValue("@Name", villainName);
            villainId = (int)command.ExecuteScalar();
            return villainId;
        }

        private static void AddMinion(SqlConnection connection, string minionName, string minionAge, int townId, int villainId, string villainName)
        {
            string getMinionNameCount = @"SELECT COUNT(Name) FROM Minions WHERE Name = @MinionName";
            SqlCommand command = new SqlCommand(getMinionNameCount, connection);
            command.Parameters.AddWithValue("@MinionName", minionName);
            int count = (int)command.ExecuteScalar();

            if (count < 1)
            {
                string addMinion = "INSERT INTO Minions(Name,Age,TownId) VALUES(@Name,@Age,@TownId)";
                command = new SqlCommand(addMinion, connection);
                command.Parameters.AddWithValue("@Name", minionName);
                command.Parameters.AddWithValue("@Age", minionAge);
                command.Parameters.AddWithValue("@TownId", townId);
                command.ExecuteNonQuery();

                string getMinionId = "SELECT Id FROM Minions WHERE Name = @Name";
                command = new SqlCommand(getMinionId, connection);
                command.Parameters.AddWithValue("@Name", minionName);
                int minionId = (int)command.ExecuteScalar();
                command.ExecuteNonQuery();

                string setVillainMinion = "INSERT INTO VillainsMinions(VillainId,MinionId) VALUES (@VillainId,@MinionId)";
                command = new SqlCommand(setVillainMinion, connection);
                command.Parameters.AddWithValue("@VillainId", villainId);
                command.Parameters.AddWithValue("@MinionId", minionId);
                command.ExecuteNonQuery();

                Console.WriteLine($"Sucessfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
