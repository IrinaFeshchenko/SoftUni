using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public void Run()
    {
        List<Soldier> army = new List<Soldier>();

        King king = new King(Console.ReadLine());

        List<string> royalGuards = Console.ReadLine()
                                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();

        army.AddRange(royalGuards.Select(n=>new RoyalGuard(n)));

        List<string> footmans = Console.ReadLine()
                                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();

        army.AddRange(footmans.Select(n => new Footman(n)));

        army.ForEach(n => king.UnderAttack += n.KingUnerAttack);

        string[] input;
        while ((input=Console.ReadLine().Split())[0]!="End")
        {

            if (input[0]=="Attack")
            {
                king.OnUnderAttack();
            }
            else if (input[0]=="Kill")
            {
                var soldier = army.First(s => s.Name == input[1]);
                king.UnderAttack -= soldier.KingUnerAttack;
                army.Remove(soldier);
            }
        }
    }
}
