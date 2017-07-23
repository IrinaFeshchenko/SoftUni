using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Model { get; }
    public string Color { get; }
    public int Battery { get; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Engine stop";
    }
}
