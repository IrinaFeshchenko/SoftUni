using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Threeuple<T,U,P>
{
    public Threeuple(T item1, U item2, P item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public T Item1 { get; private set; }

    public U Item2 { get; private set; }

    public P Item3 { get; private set; }


    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
    }
}
