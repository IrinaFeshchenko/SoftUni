namespace _4.Academy_Graduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, double[]> students = new SortedDictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(double.Parse)
                                    .ToArray();

                students.Add(name,nums);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
