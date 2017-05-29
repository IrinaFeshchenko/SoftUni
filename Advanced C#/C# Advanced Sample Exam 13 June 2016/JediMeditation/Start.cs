namespace stringMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Start
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            bool yodaIsPresent = false;
            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padwans = new Queue<string>();
            Queue<string> toshkoAndSlav = new Queue<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var jedi in args)
                {

                    if (jedi[0] == 'y')
                    {
                        yodaIsPresent = true;
                    }
                    else if (jedi[0] == 'm')
                    {
                        masters.Enqueue(jedi);
                    }
                    else if (jedi[0] == 'k')
                    {
                        knights.Enqueue(jedi);
                    }
                    else if (jedi[0] == 'p')
                    {
                        padwans.Enqueue(jedi);
                    }
                    else if (jedi[0] == 't' || jedi[0] == 's')
                    {
                        toshkoAndSlav.Enqueue(jedi);
                    }
                }
            }

            if (yodaIsPresent)
            {
                Console.Write(string.Join(" ", masters));
                Console.Write(" ");
                Console.Write(string.Join(" ", knights));
                Console.Write(" ");
                Console.Write(string.Join(" ", toshkoAndSlav));
                Console.Write(" ");
                Console.Write(string.Join(" ", padwans));
            }
            else
            {
                Console.Write(string.Join(" ", toshkoAndSlav));
                Console.Write(" ");
                Console.Write(string.Join(" ", masters));
                Console.Write(" ");
                Console.Write(string.Join(" ", knights));
                Console.Write(" ");
                Console.Write(string.Join(" ", padwans));
            }
        }
    }
}
