namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            List<long> arr = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(long.Parse)
                                    .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                    break;

                string[] command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index >= arr.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        if (index == arr.Count - 1)
                        {
                            continue;
                        }

                        int count = arr.Count - index - 1;

                        var arr2 = arr.Skip(index + 1).Take(count).ToList();
                        arr.RemoveRange((int)index + 1, count);
                        arr.InsertRange(0, arr2); 
                    }
                }
                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        long maxVal = long.MinValue;
                        long maxIndex = -1;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] % 2 == 0)
                            {
                                if (arr[i] >= maxVal)
                                {
                                    maxVal = arr[i];
                                    maxIndex = i;
                                }
                            }
                        }

                        if (maxIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(maxIndex);
                        }
                    }
                    else if (command[1] == "odd")
                    {
                        long maxVal = long.MinValue;
                        long maxIndex = -1;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] % 2 != 0)
                            {
                                if (arr[i] >= maxVal)
                                {
                                    maxVal = arr[i];
                                    maxIndex = i;
                                }
                            }
                        }

                        if (maxIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(maxIndex);
                        }
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        long minVal = long.MaxValue;
                        long minIndex = -1;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] % 2 == 0)
                            {
                                if (arr[i] <= minVal)
                                {
                                    minVal = arr[i];
                                    minIndex = i;
                                }
                            }
                        }

                        if (minIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(minIndex);
                        }
                    }
                    else if (command[1] == "odd")
                    {
                        long minVal = long.MaxValue;
                        long minIndex = -1;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i] % 2 != 0)
                            {
                                if (arr[i] <= minVal)
                                {
                                    minVal = arr[i];
                                    minIndex = i;
                                }
                            }
                        }

                        if (minIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(minIndex);
                        }
                    }
                }
                else if (command[0] == "first")
                {
                    long count = long.Parse(command[1]);

                    if (count > arr.Count)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {

                        List<long> result = new List<long>();

                        if (command[2] == "even")
                        {
                            foreach (var num in arr)
                            {
                                if (num % 2 == 0 && result.Count < count)
                                {
                                    result.Add(num);
                                }
                            }
                        }
                        else if (command[2] == "odd")
                        {
                            foreach (var num in arr)
                            {
                                if (num % 2 != 0 && result.Count < count)
                                {
                                    result.Add(num);
                                }
                            }
                        }
                 
                        Console.WriteLine("[" + string.Join(", ", result) + "]"); 
                    }
                }
                else if (command[0] == "last")
                {
                    long count = long.Parse(command[1]);

                    if (count > arr.Count)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        List<long> result = new List<long>();

                        if (command[2] == "even")
                        {
                            foreach (var num in arr.ToArray().Reverse())
                            {
                                if (num % 2 == 0 && result.Count < count)
                                {
                                    result.Add(num);
                                }
                            }
                        }
                        else if (command[2] == "odd")
                        {
                            foreach (var num in arr.ToArray().Reverse())
                            {
                                if (num % 2 != 0 && result.Count < count)
                                {
                                    result.Add(num);
                                }
                            }
                        }
                        result.Reverse();
                        Console.WriteLine("[" + string.Join(", ", result) + "]"); 
                    }
                }
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }
    }
}
