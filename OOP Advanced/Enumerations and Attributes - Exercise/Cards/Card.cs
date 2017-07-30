using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Card:IComparable<Card>
{
    public Card(string rank, string suit)
    {
        Rank = (Rank)Enum.Parse(typeof(Rank),rank);
        Suit = (Suit)Enum.Parse(typeof(Suit),suit);
    }

    public int Power => (int)this.Rank + (int)this.Suit;

    public string Name => $"{this.Rank} of {this.Suit}";

    public Rank Rank { get;private set; }

    public Suit Suit { get;private set; }

    public override string ToString()
    {
        return $"Card name: {this.Name}; Card power: {this.Power}";
    }

    public int CompareTo(Card other)
    {
        return this.Power.CompareTo(other.Power);
    }
}
