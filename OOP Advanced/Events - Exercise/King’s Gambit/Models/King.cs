using System;
using System.Collections.Generic;
using System.Linq;

public class King : IAttackable
{
    public event EventHandler UnderAttack;

    public King(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public void OnUnderAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        if (UnderAttack!=null)
        {
            UnderAttack(this, new EventArgs());
        }
    }
}
