namespace _11.Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            List<string> filters = new List<string>();

            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "Print") break;

                if (args[0]== "Add filter")
                {
                    filters.Add($"{args[1]} {args[2]}");
                }
                else if (args[0] == "Remove filter")
                {
                    filters.Remove($"{args[1]} {args[2]}");
                }
            }


            foreach (var filter in filters)
            {
                var args = filter.Split(' ');

                if (args[0] == "Starts")
                {
                    names = names.Where(x=>!x.StartsWith(args[2])).ToList();
                }
                else if (args[0] == "Ends")
                {
                    names = names.Where(x => !x.EndsWith(args[2])).ToList();
                }
                else if (args[0] == "Length")
                {
                    names = names.Where(x => x.Length != int.Parse(args[1])).ToList();
                }
                else if (args[0] == "Contains")
                {
                    names = names.Where(x => !x.Contains(args[1])).ToList();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
