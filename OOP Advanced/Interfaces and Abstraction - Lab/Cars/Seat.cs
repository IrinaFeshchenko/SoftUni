﻿public class Seat: ICar
{
    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Model { get; }
    public string Color { get; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Engine stop";
    }

    public override string ToString()
    {
        return base.ToString();
    }
}