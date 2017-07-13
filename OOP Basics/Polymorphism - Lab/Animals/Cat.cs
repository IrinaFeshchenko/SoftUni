using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Cat:Animal
{
    public Cat(string name, string favouriteFood) : base(name, favouriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return base.ExplainMyself()+Environment.NewLine+"MEEOW";
    }
}
