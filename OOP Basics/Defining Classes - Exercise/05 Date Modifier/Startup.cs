namespace _05_Date_Modifier
{
    using System;

    public class Startup
    {
        static void Main()
        {
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();

            var dateModifier = new DateModifier();
            dateModifier.CalculateDatesDifference(date1,date2);

            Console.WriteLine(dateModifier.GetDaysDifference());
        }
    }
}
