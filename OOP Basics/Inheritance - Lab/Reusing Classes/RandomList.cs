using System;
using System.Collections;

public class RandomList:ArrayList
{
    private ArrayList list;
    public RandomList()
    {
        list = new ArrayList();
    }

    public string RandomString()
    {
        var random = new Random();
        string randomString = list[random.Next(list.Count)].ToString();
        return randomString;
    }
}