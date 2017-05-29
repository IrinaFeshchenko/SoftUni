namespace _7.Print_All_Minion_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class Startup
    {
        static void Main()
        {
            List<string> minions = new List<string>();

            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connection.Open();
            using (connection)
            {
                string query = "SELECT Name FROM Minions";
                SqlCommand command = new SqlCommand(query,connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader["Name"]);
                    }
                }
            }

            for (int i = 0, p = 0; i < minions.Count;p++)
            {
                Console.WriteLine($"{minions[i++],-10} {minions[p]}");
                Console.WriteLine($"{minions[i++],-10} {minions[minions.Count - p - 1]}");
            }
        }
    }
}
