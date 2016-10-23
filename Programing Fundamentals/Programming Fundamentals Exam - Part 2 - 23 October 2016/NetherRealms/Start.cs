namespace NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Start
    {
        static void Main()
        {
            string s = Console.ReadLine();

            string[] args = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            char[] c = "0123456789+-*/.".ToCharArray();


            List<string> result = new List<string>();
            foreach (var item in args)
            {
                item.TrimEnd(',');
                long lettersSum = 0;

                foreach (var ch in item)
                {
                    if(!c.Contains(ch))
                    //if (char.IsLetter(ch))
                    {
                        lettersSum += (long)ch;
                    }
                }

                string currentNumber = "";
                decimal? lastDigit = null;
                char operation = '+';
                decimal sum = 0;

                foreach (var ch in item)
                {
                    long currentDigit = 0;
                    if (char.IsDigit(ch))
                    {
                        currentNumber += ch;
                    }
                    else if (ch == '+')
                    {
                        operation = '+';
                    }
                    else if (ch == '-')
                    {
                        operation = '-';
                    }
                    else if (ch == '.')
                    {
                        currentNumber += '.';
                    }
                    else
                    {
                        if (currentNumber != "")
                        {
                            if (operation == '+')
                            {
                                sum += decimal.Parse(currentNumber);
                                currentNumber = "";
                            }
                            else if (operation == '-')
                            {
                                sum -= decimal.Parse(currentNumber);
                                operation = '+';
                                currentNumber = "";
                            }
                        }

                    }
                }

                foreach (var ch in item)
                {
                    if (ch == '*')
                    {
                        sum *= 2;
                    }
                    if (ch == '/')
                    {
                        sum /= 2;
                    }
                }

                result.Add($"{item.Trim(',')} - {lettersSum} health, {sum:f2} damage");
            }

            var r = result.OrderBy(x=>x);
            foreach (var item in r)
            {
                Console.WriteLine(item);
            }
        }
    }
}
