using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonStats
    {
        public long Damage { get; set; }
        public long Health { get; set; }
        public long Armor { get; set; }
    }

    public class Startup
    {
        private const long DefaultDamage = 45;
        private const long DefaultHealth = 250;
        private const long DefaultArmor = 10;

        public static void Main()
        {
            Dictionary<string, SortedDictionary<string, DragonStats>> dragons = new Dictionary<string, SortedDictionary<string, DragonStats>>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string type = args[0];
                string name = args[1];
                long damage = args[2] != "null" ? long.Parse(args[2]) : DefaultDamage;
                long health = args[3] != "null" ? long.Parse(args[3]) : DefaultHealth;
                long armor = args[4] != "null" ? long.Parse(args[4]) : DefaultArmor;

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new SortedDictionary<string, DragonStats>());
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new DragonStats());
                }

                dragons[type][name].Damage = damage;
                dragons[type][name].Health = health;
                dragons[type][name].Armor = armor;
            }

            foreach (var type in dragons)
            {
                string dragonType = type.Key;
                double averageDamage = type.Value.Select(x => x.Value.Damage).Average();
                double averageHealth = type.Value.Select(x => x.Value.Health).Average();
                double averageArmor = type.Value.Select(x => x.Value.Armor).Average();

                Console.WriteLine($"{dragonType}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in type.Value)
                {
                    string name = dragon.Key;
                    long damage = dragon.Value.Damage;
                    long health = dragon.Value.Health;
                    long armor = dragon.Value.Armor;

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
