using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private readonly IList<CoffeeType> coffeeSold;

    private int coins;

    public CoffeeMachine()
    {
        this.coffeeSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeeSold;

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        if (coins>=(int)coffeePrice)
        {
            this.coffeeSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin coinValue = (Coin)Enum.Parse(typeof(Coin), coin);
        coins += (int)coinValue;
    }
}
