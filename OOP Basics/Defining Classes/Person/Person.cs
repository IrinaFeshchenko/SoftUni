

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Person
    {
        public string a;
        public int b;
        public Person() { }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class DefineClassPerson
    {
        static void Main()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            Person Pesho = new Person {a="",b=3};
            Person Gosho = new Person("Gosho", 18);
        }
    }
}
