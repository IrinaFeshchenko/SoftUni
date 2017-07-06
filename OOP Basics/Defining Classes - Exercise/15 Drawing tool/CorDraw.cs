using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Drawing_tool
{
    public class CorDraw
    {
        public void Draw()
        {
            string figure = Console.ReadLine();

            if (figure == "Square")
            {
                int n = int.Parse(Console.ReadLine());
                Square square = new Square();
                square.Draw(n);
            }

            if (figure == "Rectangle")
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                Rectangle rectangle = new Rectangle();
                rectangle.Draw(n, m);
            }
        }
    }
}
