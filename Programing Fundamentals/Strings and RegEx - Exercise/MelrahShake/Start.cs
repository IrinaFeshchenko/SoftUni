namespace MelrahShake
{
    using System;

    public static class Start
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int first = text.IndexOf(pattern, 0);
                int last = text.LastIndexOf(pattern);

                if (first != last)
                {
                    text = text.Remove(last, pattern.Length);
                    text = text.Remove(first, pattern.Length);

                    Console.WriteLine("Shaked it.");

                    if (pattern.Length < 2)
                    {
                        Finish(text);
                        break;
                    }
                    else
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                }
                else
                {
                    Finish(text);
                    break;
                }
            }
        }

        private static void Finish(string text)
        {
            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}
