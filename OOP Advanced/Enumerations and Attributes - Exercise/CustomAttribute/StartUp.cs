namespace CustomAttribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            bool isRunning = true;
            while (isRunning)
            {
                string command = System.Console.ReadLine();
                var weapon = new Weapon();
                
                if (isRunning)
                {
                    if (command=="Author")
                    {
                        string attributeValue = ((Book)typeof(Weapon).GetCustomAttributes(typeof(Book),true).First()).Author;
                        Console.WriteLine($"Author: {attributeValue}");
                    }
                    else if (command == "Revision")
                    {
                        int attributeValue = ((Book)typeof(Weapon).GetCustomAttributes(typeof(Book), true).First()).Revision;
                        Console.WriteLine($"Revision: {attributeValue}");
                    }
                    else if (command == "Description")
                    {
                        string attributeValue = ((Book)typeof(Weapon).GetCustomAttributes(typeof(Book), true).First()).Description;
                        Console.WriteLine($"Description: {attributeValue}");
                    }
                    else if (command == "Reviewers")
                    {
                        var attributeValue = ((Book)typeof(Weapon).GetCustomAttributes(typeof(Book), true).First()).Reviewers;
                        Console.WriteLine($"Reviewers: {string.Join(", ", attributeValue)}");
                    }
                    else if (command == "END")
                    {
                        isRunning = false;
                    }
                }
            }
        }
    }
}
