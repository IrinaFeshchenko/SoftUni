using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Pokemon_Trainer
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "Tournament") break;

                var trainerName = args[0];
                var pokemonName = args[1];
                var pokemonElement = args[2];
                var pokemonHealth = args[3];

                var pokemon = new Pokemon(pokemonName,pokemonElement,int.Parse(pokemonHealth));

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName,new Trainer(trainerName,new List<Pokemon>{pokemon}));
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(pokemon);

                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") break;

                if (command == "Fire")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        if (trainer.Pokemons.Any(p=>p.Element=="Fire"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }

                            trainer.Pokemons = trainer.Pokemons.Where(p=>p.Health>0).ToList();
                        }
                    }
                }
                else if (command == "Electricity")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Electricity"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }

                            trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                        }
                    }
                }
                else if (command == "Water")
                {
                    foreach (var trainer in trainers.Values)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Water"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            foreach (var pokemon in trainer.Pokemons)
                            {
                                pokemon.Health -= 10;
                            }

                            trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                        }
                    }
                }
            }

            foreach (var trainer in trainers.Values.OrderByDescending(t=>t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
