using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier
{
    protected Soldier(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public abstract void KingUnerAttack(Object sender, EventArgs e);
}
