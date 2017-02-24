
namespace _6.Remove_Villain
{
    using System;
    using System.Data.SqlClient;

    class Startup
    {
        static void Main()
        {
            // get user input
            Console.Write("Enter Villain ID: ");
            int villainId = int.Parse(Console.ReadLine());
            // create db connection
            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connection.Open();
            using (connection)
            {
                // get villain name
                string queryGetVillainName = "SELECT Name FROM Villains WHERE Id = @Id";
                SqlCommand command = new SqlCommand(queryGetVillainName, connection);
                command.Parameters.AddWithValue("@Id", villainId);
                string villainName = (string)command.ExecuteScalar();

                if (villainName!=null)
                {
                    // release minions
                    string queryReleaseMinions = "DELETE FROM VillainsMinions WHERE VillainId = @Id";
                    command = new SqlCommand(queryReleaseMinions, connection);
                    command.Parameters.AddWithValue("@Id", villainId);
                    int releasedMinions = command.ExecuteNonQuery();
                    // delete villain
                    string queryDeleteVillain = "DELETE FROM Villains WHERE Id = @Id";
                    command = new SqlCommand(queryDeleteVillain, connection);
                    command.Parameters.AddWithValue("@Id", villainId);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"{villainName} was deleted");
                    Console.WriteLine($"{releasedMinions} minions released");
                }
                else
                {
                    Console.WriteLine("No such villain was found");
                }
            }
        }
    }
}
