

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class SpyHard
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();

            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    //letter number
                    count += char.ToLower(s[i]) - 96;
                }
                else
                {
                    //ascii
                    count += s[i];
                }
            }
            string result = DecimalToN(count, n);
            Console.WriteLine("{0}{1}{2}", n, s.Length, result);
        }

        private static string DecimalToN(long decimalNumber, int numBase)
        {
            StringBuilder resultBuilder = new StringBuilder();
            int reminder = 0;

            while (decimalNumber != 0)
            {
                reminder = (int)(decimalNumber % numBase);
                resultBuilder.Append(decHexVal[reminder]);
                decimalNumber /= numBase;
            }

            //reverse the result and remove leading zeroes
            string result = resultBuilder.ToString();
            result = String.Join("", result.Reverse());
            result = result.TrimStart('0');
            result = result.ToUpper();
            return result;
        }

        private static Dictionary<int, char> decHexVal = new Dictionary<int, char>
        {
            { 0,'0'},
            { 1,'1'},
            { 2,'2'},
            { 3,'3'},
            { 4,'4'},
            { 5,'5'},
            { 6,'6'},
            { 7,'7'},
            { 8,'8'},
            { 9,'9'},
            {10,'A'},
            {11,'B'},
            {12,'C'},
            {13,'D'},
            {14,'E'},
            {15,'F'},
        };
    }
}
