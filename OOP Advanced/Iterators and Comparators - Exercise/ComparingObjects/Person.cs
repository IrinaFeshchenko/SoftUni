using System;

public class Person:IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        Name = name;
        Age = age;
        Town = town;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Town { get; private set; }

    public int CompareTo(Person other)
    {
        if (this.Name!=other.Name)
        {
            return this.Name.CompareTo(other.Name);
        }

        if (this.Age!= other.Age)
        {
            return this.Age.CompareTo(other.Age);
        }

        if (this.Town != other.Town)
        {
            return this.Town.CompareTo(other.Town);
        }

        return 0;
    }
}
