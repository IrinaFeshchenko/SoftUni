using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T>: IEnumerable<T>
{
    private const int InitialCapacity = 10;
    private T[] elements;

    public Stack()
    {
        this.elements = new T[InitialCapacity];
        this.Count = 0;
    }

    public int Count { get; set; }

    public int Capacity
    {
        get =>this.elements.Length;
    }
    public void Push(T element)
    {
        if (this.Count== this.elements.Length)
        {
            this.Resize();
        }
        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count ==0)
        {
            throw new InvalidOperationException("No elements");
        }
        var tempElement = this.elements[Count - 1];
        this.Count--;
        return tempElement;
    }

    private void Resize()
    {
        //this.elements = this.elements.Concat(new T[this.Capacity]).ToArray();
        Array.Resize(ref this.elements, 2 * this.Count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count-1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
