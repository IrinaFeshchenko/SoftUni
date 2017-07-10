namespace Wild_farm.Models
{
    using System;

    public abstract class Felime : Mammal
    {
        protected Felime(string name, string type, double weight, string livingRegion)
            : base(name, type, weight, livingRegion)
        {
        }
    }
}
