namespace Animals
{
    using Animals.Factories;
    using Animals.Models;
    using System;

    public class Program
    {
        public static void Main()
        {
            AnimalFactory animalFactory = new AnimalFactory();

            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!") break;

                string animalTokens = Console.ReadLine();

                try
                {
                    Animal animal = animalFactory.GetAnimal(animalType, animalTokens);
                    Console.WriteLine(animal);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
