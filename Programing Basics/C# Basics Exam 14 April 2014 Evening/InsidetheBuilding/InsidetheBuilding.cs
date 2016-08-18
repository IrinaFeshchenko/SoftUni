

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class InsidetheBuilding
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            int hLeft = 0;
            int hRight = 3 * h;
            int hTop = h;
            int hBottom = 0;
            int vLeft = h;
            int vRight = 2 * h;
            int vTop = 4 * h;
            int vBottom = 0;

            for (int i = 0; i < 5; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                bool verticalIn = false;
                bool horizontalIn = false;

                if((x>=vLeft&& x<=vRight)&&(y>=vBottom&&y<=vTop))
                {
                    verticalIn = true;
                }

                if ((x >= hLeft && x <= hRight) && (y >= hBottom && y <= hTop))
                {
                    horizontalIn = true;
                }

                if (verticalIn || horizontalIn)
                {
                    Console.WriteLine("inside");
                }
                else
                {
                    Console.WriteLine("outside");
                }
            }
        }
    }
}
