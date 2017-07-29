using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ListyIterator
{
    public class Startup
    {
        public static void Main()
        {
            bool isRunning = true;
            var args = Console.ReadLine().Split(' ').ToList();
            args.RemoveAt(0);

            if (args.Count==0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                try
                {
                    var list = new ListyIterator<string>(args);

                    while (isRunning)
                    {
                        string command = Console.ReadLine();

                        if (command == "END")
                        {
                            isRunning = false;
                        }
                        else if (command == "Move")
                        {
                            Console.WriteLine(list.Move());
                        }
                        else if (command == "Print")
                        {
                            list.Print();
                        }
                        else if (command == "HasNext")
                        {
                            Console.WriteLine(list.HasNext());
                        }
                        else if (command == "PrintAll")
                        {
                            Console.WriteLine(string.Join(" ", list));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
