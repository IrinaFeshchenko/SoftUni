namespace _04.Average_of_Doubles
{
    using System;
    using System.Linq;

    public class Startup    {        public static void Main()        {
            var number = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(double.Parse)
                                        .Average();

            Console.WriteLine($"{number:f2}");
        }    }
}
