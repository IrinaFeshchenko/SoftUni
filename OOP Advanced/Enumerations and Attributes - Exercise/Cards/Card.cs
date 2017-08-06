using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Card:IComparable<Card>,IEquatable<Card>
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

    //public override string ToString()
   // {
        //return $"Card name: {this.Name}; Card power: {this.Power}";
   // }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        int rankComparison = this.Suit.CompareTo(other.Suit);
        if (rankComparison != 0) return rankComparison;
        return this.Rank.CompareTo(other.Rank);
    }

    public bool Equals(Card other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (ReferenceEquals(null, other)) return false;
        return this.Power == other.Power;
    }
}
