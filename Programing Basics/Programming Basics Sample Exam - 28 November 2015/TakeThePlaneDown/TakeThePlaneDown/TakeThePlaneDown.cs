

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TakeThePlaneDown
    {
        static void Main()
        {
            int baseX = int.Parse(Console.ReadLine());
            int baseY = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int planesAproaching = int.Parse(Console.ReadLine());
            int planeX = 0, planeY = 0;
            List<string> result = new List<string>();
            for (int i = 1; i <= planesAproaching * 2; i++)
            {
                if (i % 2 != 0)
                {
                    planeX = int.Parse(Console.ReadLine());
                }
                else
                {
                    planeY = int.Parse(Console.ReadLine());

                    bool inXrange = Math.Abs(baseX - planeX) <= distance;
                    bool inYRange = Math.Abs(baseY - planeY) <= distance;
                    if (inXrange && inYRange)
                    {
                        result.Add(string.Format("You destroyed a plane at [{0},{1}]", planeX, planeY));
                    }
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
