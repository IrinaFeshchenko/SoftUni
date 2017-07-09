using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_farm.Factories;

namespace Wild_farm
{
    public class Program
    {
        static void Main()
        {
            try
            {
                while (true)
                {
                    string[] animalTokens = Console.ReadLine().Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (animalTokens[0] == "End") break;

                    string[] foodTokens = Console.ReadLine().Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (animalTokens[0] == "End") break;


                    var animal = AnimalFactory.GetAnimal(animalTokens);

                    var food = FoodFactory.GetFood(foodTokens);

                    Console.WriteLine(animal.MakeSound());
                    animal.EatFood(food);
                    Console.WriteLine(animal);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
