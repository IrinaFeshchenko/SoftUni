using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Drawing_tool
{
    public class Rectangle
    {
        public void Draw(int n, int m)
        {
            Console.WriteLine("|" + (new string('-', n)) + "|");

            for (int i = 0; i < m-2; i++)
            {
                Console.WriteLine("|" + (new string(' ', n)) + "|");
            }

            Console.WriteLine("|" + (new string('-', n )) + "|");
        }
    }
}
