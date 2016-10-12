

namespace LittleJohn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Arrow
    {
        public Arrow(string arrow, int count)
        {
            this.ArrowSize = arrow;
            this.Count = count;
        }
        public string ArrowSize { get; set; }
        public long Count { get; set; }
    }

    class Start
    {
        static void Main()
        {
            Arrow[] arrows = InitialiseArrows();
            const long rows = 4;
            arrows = ParseInput(arrows, rows);
            long number = GenerateNumber(arrows);

            string binaryNumber = Convert.ToString(number, 2);
            string reversedBinaryNumber = new string(binaryNumber.Reverse().ToArray());
            string concatenatedNumbers = binaryNumber + reversedBinaryNumber;
            var resultNumber = Convert.ToInt64(concatenatedNumbers,2);

            Console.WriteLine(resultNumber);
        }

        private static long GenerateNumber(Arrow[] arrows)
        {
            long number = 0;
            for (int i = 0; i < arrows.Length; i++)
            {
                long count = arrows[i].Count * (int)Math.Pow(10, i);
                number += count;
            }
            return number;
        }

        private static Arrow[] InitialiseArrows()
        {
            Arrow[] arrows = new Arrow[3];
            arrows[0] = new Arrow(">>>----->>", 0);
            arrows[1] = new Arrow(">>----->", 0);
            arrows[2] = new Arrow(">----->", 0);
            return arrows;
        }

        static Arrow[] ParseInput(Arrow[] arrows, long rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < arrows.Length; j++)
                {
                    Arrow arrow = arrows[j];
                    string[] parts = line.Split(new string[] { arrow.ArrowSize }, StringSplitOptions.None);
                    arrow.Count += parts.Length - 1;
                    line = string.Join(" ", parts);
                }
            }
            return arrows;
        }
    }
}