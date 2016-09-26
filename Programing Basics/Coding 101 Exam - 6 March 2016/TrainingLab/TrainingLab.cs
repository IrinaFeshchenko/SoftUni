

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TrainingLab
    {
        static void Main()
        {
            long h = (long)(double.Parse(Console.ReadLine())*100);
            double w = (long)(double.Parse(Console.ReadLine())*100);

            

            long width = (long)w - 100;
            long wplaces = (long)width / 70;

            long hplaces = (long)h / 120;
            long workPlaces = (wplaces * hplaces)-3; 
            Console.WriteLine(workPlaces);
        }
    }
}
