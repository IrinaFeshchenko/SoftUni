using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private readonly IList<Card> cards;

    public Player(string name)
    {
        this.cards = new List<Card>();
        this.Name = name;
    }

    public string Name { get; }

    public int CardsCount() => cards.Count;

    public void AddCard(Card card)
    {
        this.cards.Add(card);
    }

    public Card GetHighestCard() => cards.First(c => c.Power == cards.Select(p=>p.Power).Max());

    public override string ToString()
    {
        return $"{this.Name} wins with {this.GetHighestCard().Name}.";
    }

    public bool ContainsCard(Card card)
    {
        return this.cards.Contains(card);
    }
}
