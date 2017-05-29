namespace IndexOfLetters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            string input = File.ReadAllText("input.txt").Trim();

            StringBuilder sb = new StringBuilder();

            foreach (var ch in input)
            {
                sb.AppendLine($"{ch} -> {ch-'a'}");
            }

            File.WriteAllText("output.txt", sb.ToString());
        }
    }
}