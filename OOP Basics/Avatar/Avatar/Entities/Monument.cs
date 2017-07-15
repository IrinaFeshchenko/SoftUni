using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Monument
{
    //•	Name – a string, holding the name of the Monument.
    private string name;

    public Monument(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        string monumentType = this.GetType().Name;
        int typeEnd = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(typeEnd," ");

        return $"{monumentType}: {this.Name}";
    }
}
