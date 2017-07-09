namespace Animals.Models.Animals.Cats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tomcat : Cat
    {
        private const GenderType tomcatGender = GenderType.male;
        public Tomcat(string name, int age) : base(name, age, tomcatGender)
        {
        }

        public override string ToString()
        {
            return "Give me one million b***h";
        }
    }
}
