namespace Animals.Factories
{
    using Animals.Models;
    using Animals.Models.Animals;
    using Animals.Models.Animals.Cats;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Animals.Models.Animal;

    public class AnimalFactory
    {
        public Animal GetAnimal(string animalType, string animalData)
        {
            string[] tokens = animalData.Split(new[] { ' ','\t','\n'},StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), tokens[2].ToLower());

            if (animalType == "Cat")
            {
                return new Cat(name, age, gender);
            }
            if (animalType == "Dog")
            {
                return new Dog(name, age, gender);
            }
            if (animalType == "Frog")
            {
                return new Frog(name, age, gender);
            }
            if (animalType == "Kitten")
            {
                return new Kitten(name, age);
            }
            if (animalType == "Cat")
            {
                return new Tomcat(name, age);
            }
            return null;
        }
    }
}
