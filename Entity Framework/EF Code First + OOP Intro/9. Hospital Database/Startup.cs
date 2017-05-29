namespace _9.Hospital_Database
{
    using System;
    using System.Globalization;

    class Startup
    {
        static void Main()
        {
            Patient ivan = new Patient()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Address = "456 Baker str.",
                Email = "ivan@yahoo.com",
                DateOfBirth = DateTime.ParseExact("01/01/1980", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                HasInsurance =true,
            };

            var context = new HospitalDBcontext();
            context.patients.Add(ivan);
            context.SaveChanges();
        }
    }
}
