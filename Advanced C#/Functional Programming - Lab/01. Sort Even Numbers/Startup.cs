namespace _01.Sort_Even_Numbers
{
    using System;    using System.Collections.Generic;
    using System.Linq;

    public class Startup    {        public static void Main()        {            int[] nums = Console.ReadLine()
                                    .Split(new[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            nums.Where(x => x % 2 == 0).OrderBy(x => x).ToList().ForEach(x => Console.Write($"{x}, "));
        }    }
}
