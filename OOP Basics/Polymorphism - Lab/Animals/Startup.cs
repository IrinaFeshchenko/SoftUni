using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        Animal cat = new Cat("Pesho", "Whiskas");
        Animal dog = new Dog("Gosho", "Meat");

        Console.WriteLine(cat.ExplainMyself());
        Console.WriteLine(dog.ExplainMyself());
    }
}
