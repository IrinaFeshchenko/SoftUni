using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01_Class_Box
{
    class Program
    {
        static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, heigth);

                Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurface():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
