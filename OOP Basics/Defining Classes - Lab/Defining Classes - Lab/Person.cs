using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Person(string name, int age, List<BankAccount> accounts)
        :this(name, age)
    {
        this.Accounts = accounts;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public List<BankAccount> Accounts { get => accounts; set => accounts = value; }

    public double GetBalance()
    {
        return this.accounts.Select(x => x.Balance).Sum();
    }
}

