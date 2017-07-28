using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class CustomList<T>: ICustomList<T>, IEnumerable<T>
    where T:IComparable<T>
{
    private IList<T> list;

    public CustomList()
        : this(Enumerable.Empty<T>())
    {
    }

    public CustomList(IEnumerable<T> sortedList)
    {
        this.list = new List<T>(sortedList);
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public T Remove(int index)
    {
        T temp = this.list[index];
        this.list.RemoveAt(index);
        return temp;
    }

    public bool Contains(T element)
    {
        return this.list.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        if (this.list!=null)
        {
            var temp = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = temp;
        }
    }

    public int CountGreaterThan(T element)
    {
        return this.list.Count(e=>e.CompareTo(element)>0);
    }

    public T Max()
    {
        return this.list.Max();
    }

    public T Min()
    {
        return this.list.Min();
    }

    

    public IEnumerator<T> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
