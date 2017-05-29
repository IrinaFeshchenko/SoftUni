
namespace _9.Increase_Age_Stored_Procedure
{
    using System;
    using System.Data.SqlClient;

    class Startup
    {
        static void Main()
        {
            Console.Write("Enter Minion ID: ");
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            using (connection)
            {
                string query = $"EXEC usp_GetOlder @MinionId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinionId", minionId);
                command.ExecuteNonQuery();

                query = "SELECT Name, Age FROM Minions WHERE Id = @MinionId";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinionId", minionId);
                SqlDataReader reader =  command.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                }
            }
        }
    }
}
