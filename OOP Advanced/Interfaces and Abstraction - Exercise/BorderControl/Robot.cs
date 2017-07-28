using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Robot:IIdentifiable, INameable
{
    public Robot(string name, string id)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; }

    public string Name { get; }
}
