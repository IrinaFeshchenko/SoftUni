using System;

public class Person:IComparable<Person>
{ 
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode()+this.Age;
    }

    public override bool Equals(object obj)
    {
        Person other = obj as Person;
        return ((this.Age == other.Age)&&(this.Name==other.Name));
    }

    public int CompareTo(Person other)
    {
        if (this.Name != other.Name)
        {
            return this.Name.CompareTo(other.Name);
        }

        return this.Age.CompareTo(other.Age);
    }
}
