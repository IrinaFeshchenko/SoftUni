using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T>: IEnumerable<T>
{
    private readonly IList<T> list;

    private int index;

    public ListyIterator(IList<T> list)
    {
        this.list = list;
        index = 0;
    }

    public bool Move()
    {
        bool hasNext = HasNext();
        if (hasNext)
        {
            index++;
        }

        return hasNext;
    }

    public bool HasNext()
    {
        return this.index + 1 < this.list.Count;
    }

    public void Print()
    {
        Console.WriteLine(this.list[index].ToString());
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.list)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
