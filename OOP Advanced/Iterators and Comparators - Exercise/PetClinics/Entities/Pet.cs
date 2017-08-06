using System;

public class Pet
{
    private string name;
    private int age;
    private string kind;

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (value.Length < 1 || value.Length > 100)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        private set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.age = value;
        }
    }

    public string Kind
    {
        get => this.kind;
        private set
        {
            if (value.Length < 1 || value.Length > 100)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.kind = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}
