using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Froggy
{
    public class Startup
    {
        public static void Main()
        {
            var inputStones = Console.ReadLine().Split(new[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Lake myLake = new Lake(inputStones);

            Console.WriteLine(string.Join(", ",myLake));
        }
    }
}
