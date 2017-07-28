using System.Text.RegularExpressions;

public class Smartphone : ICallable, IBrowseable
{
    public string Call(string number)
    {
        if (!Regex.IsMatch(number, @"^\d+$"))
        {
            return "Invalid number!";
        }
        else
        {
            return $"Calling... {number}";
        }
    }

    public string Browse(string site)
    {
        if (Regex.IsMatch(site, @"\d"))
        {
            return "Invalid URL!";
        }
        else
        {
            return $"Browsing: {site}!";
        }
    }
}
