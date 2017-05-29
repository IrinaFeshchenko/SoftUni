
namespace _16.Stored_Procedure
{
    using BookShopDB.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            Console.WriteLine("Enter author name:");
            string[] name = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string fName = name[0];
            string lName = name[1];

            SqlParameter fNameParameter = new SqlParameter("@fName", SqlDbType.VarChar);
            fNameParameter.Value = fName;

            SqlParameter lNameParameter = new SqlParameter("@lName", SqlDbType.VarChar);
            lNameParameter.Value = lName;

            var result = ctx.Database.SqlQuery<int>($"EXEC dbo.TotalBooksByAuthor {@fName}, {@lName}").First();
            Console.WriteLine(result);
        }
    }
}
