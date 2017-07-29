using System.Collections.Generic;

public class AgeComparator: IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Age!=y.Age)
        {
            return x.Age.CompareTo(y.Age);
        }

        return 0;
    }
}