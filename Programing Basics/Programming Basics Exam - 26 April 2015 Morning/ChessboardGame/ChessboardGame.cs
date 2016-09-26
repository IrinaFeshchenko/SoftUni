

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ChessboardGame
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine().Trim();

            ulong black = 0;
            ulong white = 0;

            for (int i = 0; (i < s.Length)&&(i<(n*n)); i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                {
                    if (char.IsUpper(s[i]))
                    {
                        if (i % 2 == 0)
                        {
                            white += s[i];
                        }
                        else
                        {
                            black += s[i];
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            black += s[i];
                        }
                        else
                        {
                            white += s[i];
                        }
                    }
                }
            }

            if (black == white)
            {
                Console.WriteLine("Equal result: {0}", black);
            }
            else if (black > white)
            {
                Console.WriteLine("The winner is: black team");
                Console.WriteLine("{0}", black - white);
            }
            else if (black < white)
            {
                Console.WriteLine("The winner is: white team");
                Console.WriteLine("{0}", white - black);
            }
        }
    }
}
