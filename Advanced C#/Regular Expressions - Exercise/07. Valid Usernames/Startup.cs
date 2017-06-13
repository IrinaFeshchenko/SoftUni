namespace _07.Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Startup    {        public static void Main()        {            string[] usernames = Console.ReadLine().Split(new[] { '/', '\\', '(', ')',' ' }, StringSplitOptions.RemoveEmptyEntries);

            Regex regex = new Regex(@"^[a-zA-Z][\w]{2,24}$");

            List<string> validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (regex.IsMatch(username))
                {
                    validUsernames.Add(username);
                }
            }

            int maxUsernameIndex = 0;
            int maxUsernameSum = 0;

            for (int i = 1; i < validUsernames.Count; i++)
            {
                int len1 = validUsernames[i].Length;
                int len2 = validUsernames[i - 1].Length;
                int currentUsernamesSum = len1 + len2;

                if (currentUsernamesSum > maxUsernameSum)
                {
                    maxUsernameIndex = i - 1;
                    maxUsernameSum = currentUsernamesSum;
                }
            }

            Console.WriteLine(validUsernames[maxUsernameIndex]);
            Console.WriteLine(validUsernames[maxUsernameIndex+1]);
        }    }
}
