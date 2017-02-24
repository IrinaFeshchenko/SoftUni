namespace _8.Increase_Minions_Age
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            Console.Write("Enter minions IDs separated by space: ");
            int[] ids = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            SqlConnection connection = new SqlConnection("Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connection.Open();

            using (connection)
            {
                IncrementAgeByOne(connection, ids);
                MakeTitlecase(connection, ids);
                PrintAllMinions(connection);
            }
        }

        private static void IncrementAgeByOne(SqlConnection connection, int[] ids)
        {
            SqlCommand command = new SqlCommand();
            string[] parameters = GetParameters(ids, command);
            command.Connection = connection;
            command.CommandText = $"UPDATE Minions SET Age+=1 WHERE Id in ({string.Join(", ", parameters)})";
            command.ExecuteNonQuery();
        }

        private static void MakeTitlecase(SqlConnection connection, int[] ids)
        {
            SqlCommand command = new SqlCommand();
            string[] parameters = GetParameters(ids, command);
            command.Connection = connection;
            command.CommandText = $@"
UPDATE Minions 
SET Name = UPPER(LEFT(Name,1)) +
case
when  (charindex(' ',Name) <2) then LOWER(SUBSTRING(Name,2,LEN(Name)))
when  (charindex(' ',Name) >1) then LOWER(SUBSTRING(Name,2,charindex(' ',Name,2)-1)) +
UPPER(SUBSTRING(Name,charindex(' ',Name,2)+1,1)) +
LOWER(SUBSTRING(Name,charindex(' ',Name,2)+2,LEN(Name)))
end
where Id in ({string.Join(", ", parameters)})";
            command.ExecuteNonQuery();
        }

        private static string[] GetParameters(int[] ids, SqlCommand command)
        {
            string[] parameters = new string[ids.Length];

            for (int i = 0; i < ids.Length; i++)
            {
                parameters[i] = $"@ids{i}";
                command.Parameters.AddWithValue(parameters[i], ids[i]);
            }
            return parameters;
        }

        private static void PrintAllMinions(SqlConnection connection)
        {
            string query = "SELECT Name, Age FROM Minions";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{(string)reader["Name"],-10} {reader["Age"].ToString()}");
                }
            }
        }
    }
}
