//You have an empty sequence, and you will be given N queries.Each query is one of these three types:
//1 x - Push the element x into the stack.
//2    - Delete the element present at the top of the stack.
//3    - Print the maximum element in the stack.
//Input Format: The first line of input contains an integer, N. The next N lines each contain an above mentioned query. (It is guaranteed that each query is valid.)
//Output Format: For each type 3 query, print the maximum element in the stack on a new line.

namespace _3.Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int inputQueriesCount = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxValues = new Stack<int>();

            for (int i = 0; i < inputQueriesCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    if ((maxValues.Count == 0) &&
                        (stack.Count == 0))
                    {
                        maxValues.Push(input[1]);
                    }

                    else if ((maxValues.Count > 0) &&

                    (input[1] >= maxValues.Peek()))
                    {
                        maxValues.Push(input[1]);
                    }

                    stack.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    if ((maxValues.Count > 0) &&
                        (stack.Peek() == maxValues.Peek()))
                    {
                        maxValues.Pop();
                    }

                    stack.Pop();
                }

                else if (input[0] == 3)

                {
                    Console.WriteLine(maxValues.Peek());
                }
            }
        }
    }
}
