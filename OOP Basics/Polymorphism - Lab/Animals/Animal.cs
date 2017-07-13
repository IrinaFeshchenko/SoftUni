using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name,string favouriteFood)
    {
        this.FavouriteFood = favouriteFood;
        this.Name = name;
    }

    public string FavouriteFood
    {
        get { return favouriteFood; }
        protected set { favouriteFood = value; }
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public virtual string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
    }
}
