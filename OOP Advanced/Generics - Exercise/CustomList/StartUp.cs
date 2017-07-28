using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CustomList
{
    public class Startup
    {
        public static void Main()
        {
            ICustomList<string> customList = new CustomList<string>();
            bool isRunning = true;
            while (isRunning)
            {
                var args = Console.ReadLine().Split().ToArray();
                string command = args[0];

                if (command=="END")
                {
                    isRunning = false;
                }
                else if (command == "Add")
                {
                    customList.Add(args[1]);
                }
                else if (command == "Remove")
                {
                    customList.Remove(int.Parse(args[1]));
                }
                else if (command == "Contains")
                {
                    Console.WriteLine(customList.Contains(args[1])?"True":"False");
                }
                else if (command == "Swap")
                {
                    customList.Swap(int.Parse(args[1]),int.Parse(args[2]));
                }
                else if (command == "Greater")
                {
                    Console.WriteLine(customList.CountGreaterThan(args[1]));
                }
                else if (command == "Max")
                {
                    Console.WriteLine(customList.Max());
                }
                else if (command == "Min")
                {
                    Console.WriteLine(customList.Min());
                }
                else if (command == "Sort")
                {
                    customList = Sorter.Sort(customList);
                }
                else if (command == "Print")
                {
                    foreach (var item in customList)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
