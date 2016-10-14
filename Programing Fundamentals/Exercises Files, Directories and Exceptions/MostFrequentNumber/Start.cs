namespace MostFrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string input = File.ReadAllText("input.txt");
            
            string[] numbers = input.Split(' ');

            Dictionary<string, int> numOccurances = new Dictionary<string, int>();

            foreach (var num in numbers)
            {
                if (!numOccurances.ContainsKey(num))
                {
                    numOccurances.Add(num, 0);
                }

                numOccurances[num]++;
            }

            var result = numOccurances.Where(x => x.Value == numOccurances.Values.Max())
                                      .Select(x => x.Key)
                                      .FirstOrDefault();

            File.WriteAllText("output.txt",result);
        }
    }
}
