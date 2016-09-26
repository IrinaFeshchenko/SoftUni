

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DifferentIntegersSize
    {
        static void Main()
        {
            string s = Console.ReadLine();

            bool canFit = false;

            try
            {
                var num = sbyte.Parse(s);
                canFit = Print(num, "* sbyte", canFit);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                var num = byte.Parse(s);
                canFit = Print(num, "* byte", canFit);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                var num = short.Parse(s);
                canFit = Print(num, "* short", canFit);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                var num = ushort.Parse(s);
                canFit = Print(num, "* ushort", canFit);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                var num = int.Parse(s);
                canFit = Print(num, "* int", canFit);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                var num = uint.Parse(s);
                canFit = Print(num, "* uint", canFit);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                var num = long.Parse(s);
                canFit = Print(num, "* long", canFit);
            }
            catch (Exception)
            {
                ;
            }

            if (!canFit)
            {
                Console.WriteLine(s+" can't fit in any type");
            }
        }

        private static bool Print(decimal num, string message, bool canFit)
        {
            if (!canFit)
            {
                Console.WriteLine($"{num} can fit in:");
            }

            Console.WriteLine(message);
            canFit = true;
            return canFit;
        }
    }
}
