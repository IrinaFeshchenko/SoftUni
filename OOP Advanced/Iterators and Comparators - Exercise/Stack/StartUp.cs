namespace Stack_
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                var stack = new Stack<string>();
                bool isRunning = true;

                while (isRunning)
                {
                    var args = Console.ReadLine().Split(new []{' ',','},StringSplitOptions.RemoveEmptyEntries).ToList();
                    string command = args[0];

                    if (command == "END")
                    {
                        isRunning = false;
                    }
                    else if (command == "Push")
                    {
                        for (int i = 1; i < args.Count; i++)
                        {
                            stack.Push(args[i]);
                        }
                    }
                    else if (command == "Pop")
                    {
                        stack.Pop();
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    foreach (var elelment in stack)
                    {
                        Console.WriteLine(elelment);
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
