namespace Animals.Models.Animals.Cats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Kitten : Cat
    {
        private const GenderType kittenGender = GenderType.female;
        public Kitten(string name, int age) : base(name, age, kittenGender)
        {
        }

        public override string ToString()
        {
            return "Miau";
        }
    }
}
