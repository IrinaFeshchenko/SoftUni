// You are given N plants in a garden.Each of these plants has been added with some amount of pesticide.After each day, if any plant has more pesticide than the plant at its left, being weaker (more GMO) than the left one, it dies.You are given the initial values of the amount of pesticide and the position of each plant.Print the number of days after which no plant dies, i.e.the time after which there are no plants with more pesticide content than the plant to their left.
// Input Format: The input consists of an integer N representing the number of plants. The next single line consists of N integers where every integer represents the position and the amount of pesticides of each plant.
// Constraints: 1 ≤ N ≤ 100000
// Pesticides amount on a plant is between 0 and 1000000000
// Output Format: Output a single value equal to the number of days after which no plants die

namespace _11.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] plant = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();


            Stack<int> stack = new Stack<int>();
            int[] daySpan = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                    daySpan[i] = 1;
                }
                else
                {
                    if (plant[i] > plant[stack.Peek()])
                    {
                        daySpan[i] = 1;
                        stack.Push(i);
                    }
                    else
                    {
                        while (stack.Count > 0 && plant[i] <= plant[stack.Peek()])
                        {
                            daySpan[i] = Math.Max(daySpan[i] ,daySpan[stack.Pop()]+1);
                        }

                        if (stack.Count == 0)
                        {
                            daySpan[i] = 1;
                        }

                        stack.Push(i);
                    }
                }
            }

            Console.WriteLine(daySpan.Max());
        }
    }
}
