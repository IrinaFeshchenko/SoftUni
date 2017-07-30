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

    public void AddCard(string inputCard)
    {
        var args = inputCard.Split(new []{" of "},StringSplitOptions.RemoveEmptyEntries);
        string rank = args[0];
        string suit = args[1];

        Card card;
        try
        {
            card = new Card(rank,suit);
        }
        catch (Exception)
        {
            throw new InvalidOperationException("No such card exists.");
        }

        if (cards.Any(c=>c.Name==card.Name))
        {
            throw new InvalidOperationException($"Card is not in the deck.");
        }

        this.cards.Add(card);
    }

    public Card GetHighestCard() => cards.First(c => c.Power == cards.Select(p=>p.Power).Max());

    public override string ToString()
    {
        return $"{this.Name} wins with {this.GetHighestCard().Name}.";
    }
}
