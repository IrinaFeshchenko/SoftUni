//We are given the following sequence of numbers:
//•	S1 = N
//•	S2 = S1 + 1
//•	S3 = 2* S1 + 1
//•	S4 = S1 + 2
//•	S5 = S2 + 1
//•	S6 = 2* S2 + 1
//•	S7 = S2 + 2
//•	…
//Using the Queue<T> class, write a program to print its first 50 members for given N.

namespace _5.Calculate_Sequence_with_Queue
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> q = new Queue<long>();
            q.Enqueue(n);
            int count = 1;
            print(q.Peek());
            long limit = 50;

            while (true)
            {
                if (count == limit) break;
                print(q.Peek() + 1);
                q.Enqueue(q.Peek() + 1);
                count++;

                if (count == limit) break;
                print(2 * q.Peek() + 1);
                q.Enqueue(2 * q.Peek() + 1);
                count++;

                if (count == limit) break;
                print(q.Peek() + 2);
                q.Enqueue(q.Dequeue() + 2);
                count++;
            }
        }

        static void print(long n)
        {
            Console.Write($"{n} ");
        }
    }
}
