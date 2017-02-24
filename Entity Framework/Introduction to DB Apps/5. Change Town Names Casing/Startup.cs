namespace _5.Change_Town_Names_Casing
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class Startup
    {
        static void Main()
        {
            System.Console.Write("Enter Country Name: ");
            string countryName = System.Console.ReadLine().Trim();

            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");

            connection.Open();
            using (connection)
            {
                string query = "SELECT top 1 Id FROM Countries WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", countryName);
                int countryId = (int?)command.ExecuteScalar()??0;

                query = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryId = @CountryId";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryId", countryId);
                int affectedRows = (int)command.ExecuteNonQuery();

                if (affectedRows>0)
                {
                    query = "SELECT Name FROM Towns WHERE CountryId = @CountryId";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CountryId", countryId);
                    SqlDataReader reader = command.ExecuteReader();

                    List<string> towns = new List<string>();
                    while (reader.Read())
                    {
                        towns.Add((string)reader["Name"]);
                    }

                    System.Console.WriteLine($"{affectedRows} town names were affected.");
                    System.Console.WriteLine("[" + string.Join(", ", towns) + "]");
                }
                else
                {
                    System.Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
