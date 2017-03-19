using _17.Call_a_Stored_Procedure.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Call_a_Stored_Procedure
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new SoftUniContext();
            Console.WriteLine("Enter employee name:");
            string[] name = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string fName = name[0];
            string lName = name[1];

            SqlParameter fNameParameter = new SqlParameter("@fName", SqlDbType.VarChar);
            fNameParameter.Value = fName;

            SqlParameter lNameParameter = new SqlParameter("@lName", SqlDbType.VarChar);
            lNameParameter.Value = lName;

            var info = ctx.Database.SqlQuery<ProjectInfo>("exec dbo.udp_FindProjectsByEmployeeName @fName, @lName", fNameParameter, lNameParameter).ToList();

            foreach (var i in info)
            {
                Console.WriteLine($"{i.Name} - {i.Description.Substring(0,25)}..., {i.startDate:dd/MMM/yyyy hh:mm:ss tt}");
            }
        }
    }
}
