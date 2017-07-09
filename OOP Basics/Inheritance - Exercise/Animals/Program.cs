namespace Animals
{
    using Animals.Factories;
    using Animals.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!") break;

                string animalTokens = Console.ReadLine();
                AnimalFactory animalFactory = new AnimalFactory();
                Animal animal = animalFactory.GetAnimal(animalType, animalTokens);
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetAnimalType());
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
