namespace _15_Drawing_tool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Square
    {
        public void Draw(int n)
        {
            Console.WriteLine("|" + (new string('-', n)) + "|");

            for (int i = 0; i < n-2; i++)
            {
                Console.WriteLine("|" + (new string(' ', n)) + "|");
            }

            Console.WriteLine("|" + (new string('-', n)) + "|");
        }
    }
}