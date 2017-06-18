namespace _12.Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Dictionary<string, Func<int[], int, bool>> filters = new Dictionary<string, Func<int[], int, bool>>();

            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "Forge") break;

                string commandType = args[0];
                string sumType = args[1];
                int excludeSum = int.Parse(args[2]);

                if (args[0] == "Exclude")
                {
                    Func<int[], int, bool> filter = createFilter(sumType, excludeSum);
                    filters.Add(sumType + excludeSum, filter);
                }
                else if (args[0] == "Reverse")
                {
                    filters.Remove(sumType + excludeSum);
                }
            }


            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                bool pass = true;
                foreach (var filter in filters)
                {
                    if (!filter.Value(numbers,i))
                    {
                        pass = false;
                    }
                }

                if (pass)
                {
                    result.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }

        private static Func<int[], int, bool> createFilter(string sumType, int excludeSum)
        {
            if (sumType == "Sum Left")
            {
                return (arr, i) =>
                {
                    int left = i-1<0?0:arr[i-1];
                    int current = arr[i];
                    return current + left != excludeSum;
                };
            }
            else if (sumType == "Sum Right")
            {
                return (arr, i) =>
                {
                    int right = (i + 1 > arr.Length) ? 0 : arr[i + 1];
                    int current = arr[i];
                    return current + right != excludeSum;
                };
            }
            else if (sumType == "Sum Left Right")
            {
                return (arr, i) =>
                {
                    int left = i - 1 < 0 ? 0 : arr[i - 1];
                    int right = (i + 1 >= arr.Length) ? 0 : arr[i + 1];
                    int current = arr[i];
                    return current + left + right != excludeSum;
                };
            }

            return null;
        }
    }
}
