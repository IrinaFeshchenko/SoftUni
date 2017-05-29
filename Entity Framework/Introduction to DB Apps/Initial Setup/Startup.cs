namespace Initial_Setup
{
    using System.Data.SqlClient;
    using System.IO;

    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS; Integrated Security=True;");

            connection.Open();

            string createDb = "create database MinionsDB";
            var createDatabaseCommand = new SqlCommand(createDb, connection);

            string createTables = File.ReadAllText("..\\..\\InitialSetup.sql");
            var createTablesCommand = new SqlCommand(createTables, connection);

            using (connection)
            {
                System.Console.WriteLine(createDatabaseCommand.ExecuteNonQuery());
                System.Console.WriteLine(createTablesCommand.ExecuteNonQuery());
            }
        }
    }
}
