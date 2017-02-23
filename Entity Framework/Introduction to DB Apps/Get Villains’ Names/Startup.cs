
using System.Data.SqlClient;
using System.IO;

namespace Get_Villains__Names
{
    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS; Integrated Security=True;");
            string query = File.ReadAllText("../../query.sql");
            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();
            using (connection)
            {
                SqlDataReader reader =  command.ExecuteReader();

                while (reader.Read())
                {
                    string villainName = (string)reader["name"];
                    int minionsCount = (int)reader["minionsCount"];

                    System.Console.WriteLine($"Villain: {villainName,-20} Minions: {minionsCount}");
                }
            }
        }
    }
}
