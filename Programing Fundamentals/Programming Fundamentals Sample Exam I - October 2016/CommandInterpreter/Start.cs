namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            List<string> array = Console.ReadLine()
                                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();

            while (true)
            {
                List<string> args = Console.ReadLine()
                                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();
                string command = args[0];
                if (command.ToLower() == "end")
                    break;

                if (command == "reverse")
                {
                    int start = int.Parse(args[2]);
                    int count = int.Parse(args[4]);

                    if (start < 0 ||
                        count < 0 ||
                        start >= array.Count ||
                        start + count > array.Count)
                    {
                        InvalidParameters("reverse args out of range");
                        continue;
                    }

                    var reversed = array.Skip(start).Take(count).Reverse().ToList();

                    array.RemoveRange(start, count);
                    array.InsertRange(start, reversed);
                }
                else if (command == "sort")
                {
                    int start = int.Parse(args[2]);
                    int count = int.Parse(args[4]);

                    if (start < 0 ||
                        count < 0 ||
                        start >= array.Count ||
                        start + count > array.Count)
                    {
                        InvalidParameters("sort args out of range");
                        continue;
                    }

                    var sorted = array.Skip(start).Take(count).OrderBy(str => str).ToList();

                    array.RemoveRange(start, count);
                    array.InsertRange(start, sorted);
                }
                else if (command == "rollLeft")
                {
                    long shift = int.Parse(args[1]);

                    if (shift < 0)
                    {
                        InvalidParameters("rollleft les than 0");
                        continue;
                    }

                    for (int i = 0; i < shift % array.Count; i++)
                    {
                        string element = array[0];
                        array.RemoveAt(0);
                        array.Add(element);
                    }
                }
                else if (command == "rollRight")
                {
                    long shift = int.Parse(args[1]);

                    if (shift < 0)
                    {
                        InvalidParameters("rollleft les than 0");
                        continue;
                    }

                    for (int i = 0; i < shift % array.Count; i++)
                    {
                        string element = array.Last();
                        array.RemoveAt(array.Count-1);
                        array.Insert(0,element);
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        private static void InvalidParameters(string message)
        {
            //Console.WriteLine($"error: {message}");
            Console.WriteLine($"Invalid input parameters.");
        }
    }
}
