using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Bender
{
    //•	Name – a string, holding the name of the Bender.
    private string name;
    //•	Power – an integer, holding the power of the Bender.
    private int power;

    public Bender(int power, string name)
    {
        this.Power = power;
        this.Name = name;
    }

    public int Power
    {
        get { return power; }
        private set { power = value; }
    }
    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public abstract double GetPower();

    public override string ToString()
    {
        string benderType = this.GetType().Name;
        int typeEnd = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEnd," ");
        return $"{benderType}: {this.Name}, Power: {this.Power}";
    }
}
