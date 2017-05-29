namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    class Start
    {
        static void Main()
        {
            string input = "input.txt";
            string output = "output.txt";

            string[] text = File.ReadAllLines(input);

            var result = text.Select((line, index) => $"{index + 1}. {line}");

            File.WriteAllLines(output,result);
        }
    }
}
