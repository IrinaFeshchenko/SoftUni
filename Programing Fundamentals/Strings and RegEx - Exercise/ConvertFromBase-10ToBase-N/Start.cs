namespace ConvertFromBaseThenToBaseN
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    public class Start
    {
        public static void Main()
        {
            string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int inputBase = int.Parse(args[0]);
            BigInteger inputNumber = BigInteger.Parse(args[1]);

            var result = DecimalToN(inputNumber,inputBase);

            Console.WriteLine(result);
        }

        private static string DecimalToN(BigInteger decimalNumber, int numBase)
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
