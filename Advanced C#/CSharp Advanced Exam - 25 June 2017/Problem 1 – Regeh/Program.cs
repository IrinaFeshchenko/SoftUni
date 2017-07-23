
namespace Problem_1___Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern1 = @"(\[[^\[\] ]*\w+<(\d+)REGEH(\d+)>\w+\])";

            var matches = Regex.Matches(input,pattern1);

            List<string> nums = new List<string>();

            foreach (Match m in matches)
            {
                nums.Add(m.Groups[2].Value);
                nums.Add(m.Groups[3].Value);
            }

            List<char> result = new List<char>();

            int sum = 0;
            foreach (var num in nums.Select(int.Parse))
            {
                int index = sum + num;

                if (index>=input.Length)
                {
                    index = index % (input.Length - 1);
                }

                result.Add(input[index]);
                sum += num;
            }

            Console.WriteLine(string.Join("",result));
        }
    }
}
