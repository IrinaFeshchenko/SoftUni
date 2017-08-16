using System;
using System.Collections.Generic;
using System.Linq;

public class Footman : Soldier,IMortal
{
    public Footman(string name) : base(name)
    {
    }

    public override void KingUnerAttack(Object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}
