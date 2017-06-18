namespace _01.Action_Print
{
    using System;    public class Startup    {        public static void Main()        {            string[] namesList = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> namePrinter = x => Console.WriteLine(x);            InvokePrint(namesList, namePrinter);        }

        private static void InvokePrint(string[] data, Action<string> namePrinter)
        {
            foreach (var item in data)
            {
                namePrinter(item);
            }
        }
    }
}
