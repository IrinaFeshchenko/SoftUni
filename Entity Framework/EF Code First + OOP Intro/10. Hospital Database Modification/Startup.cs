using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Hospital_Database_Modification
{
    class Startup
    {
        static void Main()
        {
            var context = new HospitalDBContext();
            var doc = new Doctor();
            doc.Name = "Ivan";
            doc.Specialty = "GP";
            context.Doctors.Add(doc);
            context.SaveChanges();
        }
    }
}
