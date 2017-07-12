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
            string[] tokens = animalData.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age;
            if (!int.TryParse(tokens[1], out age))
            {
                throw new ArgumentException("Invalid input!");
            }
            string gender = tokens[2];

            animalType = animalType.ToLower();


            if (animalType == "dog")
            {
                return new Dog(name, age, gender);
            }
            if (animalType == "frog")
            {
                return new Frog(name, age, gender);
            }
            if (animalType == "cat")
            {
                return new Cat(name, age, gender);
            }
            if (animalType == "kitten")
            {
                return new Kitten(name, age);
            }
            if (animalType == "tomcat")
            {
                return new Tomcat(name, age);
            }

            throw new ArgumentException("Invalid input!");
        }
    }
}
