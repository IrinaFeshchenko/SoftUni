namespace _04.Add_VAT
{
    using System;    using System.Linq;

    public class Startup    {        public static void Main()        {            string input = Console.ReadLine();            input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)                 .Select(x=>double.Parse(x)*1.2)                 .ToList()                 .ForEach(x => Console.WriteLine($"{x:f2}"));        }    }
}
