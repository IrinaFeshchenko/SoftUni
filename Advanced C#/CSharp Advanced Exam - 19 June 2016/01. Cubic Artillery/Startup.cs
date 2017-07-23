namespace _01.Cubic_Artillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        public static short capacityLeft;
        public static short bunkerCapacity;

        public static Queue<short> bunkerWeapons;

        static void Main()
        {
            bunkerCapacity = short.Parse(Console.ReadLine());
            capacityLeft = bunkerCapacity;

            Queue<char> bunkers = new Queue<char>();
            Queue<short> weapons = new Queue<short>();

            string inputLine;
            string endCommand = "Bunker Revision";

            while ((inputLine = Console.ReadLine()) != endCommand)
            {
                InitialiseBunkersAndWeapons(inputLine, bunkers, weapons);

                while (weapons.Any())
                {
                    short weapon = weapons.Peek();

                    if (FirstBunkerOverflow(bunkers, bunkerCapacity, weapon))
                    {
                        if (NoOtherBunkers(bunkers))
                        {
                            if (WeaponCanFit(bunkerCapacity, weapon))
                            {
                                FreeSpaceForTheWeapon(bunkers, weapon);
                                StoreTheWeapon(bunkers, weapons);
                            }
                            else
                            {
                                RemoveTheWeapon(weapons);
                            }
                        }
                        else
                        {
                            while (bunkers.Count > 1)
                            {
                                if (FirstBunkerOverflow(bunkers, bunkerCapacity, weapon))
                                {
                                    PrshortFirstBunker(bunkers);
                                    RemoveFirstBunker(bunkers);
                                }
                                else
                                {
                                    StoreTheWeapon(bunkers, weapons);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        StoreTheWeapon(bunkers, weapons);
                    }
                }
            }
        }

        private static void RemoveTheWeapon(Queue<short> weapons)
        {
            weapons.Dequeue();
        }

        private static void PrshortFirstBunker(Queue<char> bunkers)
        {
            var bunker = bunkers.Peek();

            if (bunkerWeapons.Any())
            {
                Console.WriteLine($"{bunker} -> {string.Join(", ", bunkerWeapons)}");
            }
            else
            {
                Console.WriteLine($"{bunker} -> Empty");
            }
        }

        private static void RemoveFirstBunker(Queue<char> bunkers)
        {
            bunkers.Dequeue();
            capacityLeft = bunkerCapacity;
        }

        private static void FreeSpaceForTheWeapon(Queue<char> bunkers, short weapon)
        {
            while (capacityLeft < weapon)
            {
                short removedWeapon = bunkerWeapons.Dequeue();
                capacityLeft = (short)(capacityLeft + removedWeapon);
            }
        }

        private static bool WeaponCanFit(short bunkerCapacity, short weapon)
        {
            return weapon <= bunkerCapacity;
        }

        private static bool NoOtherBunkers(Queue<char> bunkers)
        {
            return bunkers.Count == 1;
        }

        private static void StoreTheWeapon(Queue<char> bunkers, Queue<short> weapons)
        {
            bunkerWeapons.Enqueue(weapons.Peek());
            capacityLeft -= weapons.Peek();
            weapons.Dequeue();
        }

        private static bool FirstBunkerOverflow(Queue<char> bunkers, short bunkerCapacity, short weapon)
        {
            return capacityLeft < weapon;
        }

        private static void InitialiseBunkersAndWeapons(string inputLine, Queue<char> bunkers, Queue<short> weapons)
        {
            string[] input = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                short digit;
                bool isDigit = short.TryParse(item, out digit);

                if (isDigit)
                {
                    weapons.Enqueue(short.Parse(item));
                }
                else
                {
                    bunkers.Enqueue(char.Parse(item));
                }
            }
        }
    }
}
