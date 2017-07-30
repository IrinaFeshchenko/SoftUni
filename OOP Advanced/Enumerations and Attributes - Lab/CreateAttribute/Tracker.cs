using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var methodinfo in methods)
        {
            if (methodinfo.CustomAttributes.Any(n=>n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = methodinfo.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{methodinfo.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
