﻿namespace Wild_farm.Factories
{
    using Wild_farm.Models;
    using Wild_farm.Models.Animals;

    public class AnimalFactory
    {
        public static Animal GetAnimal(string[] tokens)
        {
            var animalType = tokens[0];
            var animalName = tokens[1];
            var animalWeight = double.Parse(tokens[2]);
            var animalRegion = tokens[3];

            switch (animalType)
            {
                case "Mouse":
                    return new Mouse(animalName, animalType, animalWeight, animalRegion);
                case "Zebra":
                    return new Zebra(animalName, animalType, animalWeight, animalRegion);
                case "Tiger":
                    return new Tigeer(animalName, animalType, animalWeight, animalRegion);
                case "Cat":
                    return new Cat(animalName, animalType, animalWeight, animalRegion, tokens[4]);
                default:
                    return null;
            }
        }
    }
}