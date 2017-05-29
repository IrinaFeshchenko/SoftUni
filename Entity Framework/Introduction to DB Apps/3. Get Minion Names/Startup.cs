namespace _3.Get_Minion_Names
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; ");

            string query = File.ReadAllText("../../query.sql");
            SqlCommand command = new SqlCommand(query,connection);
            System.Console.WriteLine("Enter Villain ID:");
            command.Parameters.AddWithValue("@villainId", System.Console.ReadLine());

            connection.Open();
            using (connection)
            {
                SqlDataReader reader = command.ExecuteReader();
                int minionCount = 1;

                if (reader.Read())
                {
                    string villainName = (string)reader["villainName"];
                    string minionName = (string)reader["minionName"];
                    int minionAge = (int)reader["age"];

                    Console.WriteLine($"Villain: {villainName}");
                    Console.WriteLine($"{minionCount++}. {minionName} {minionAge}");

                    while (reader.Read())
                    {
                        minionName = (string)reader["minionName"];
                        minionAge = (int)reader["age"];
                        Console.WriteLine($"{minionCount++}. {minionName} {minionAge}");
                    }
                }
            }
        }
    }
}
