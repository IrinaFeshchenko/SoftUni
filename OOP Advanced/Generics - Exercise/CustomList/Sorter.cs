using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static class Sorter
{
    public static ICustomList<T> Sort<T>(ICustomList<T> customList)
        where T : IComparable<T>
    {
        return new CustomList<T>(customList.OrderBy(x=>x));
    }
}
