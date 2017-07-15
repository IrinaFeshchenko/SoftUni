using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InputParser
{
    public List<string> Parse(string inputLine)
    {
        return new List<string>(inputLine.Split(new[] { ' ','\t'}, StringSplitOptions.RemoveEmptyEntries));
    }
}
