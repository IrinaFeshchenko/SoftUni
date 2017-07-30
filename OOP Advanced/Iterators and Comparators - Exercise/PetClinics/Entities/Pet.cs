public class Pet
{
    public Pet(string name, string age, string kind)
    {
        Name = name;
        Age = age;
        Kind = kind;
    }

    public string Name { get; private set; }

    public string Age { get; private set; }

    public string Kind { get;private set; }
}
