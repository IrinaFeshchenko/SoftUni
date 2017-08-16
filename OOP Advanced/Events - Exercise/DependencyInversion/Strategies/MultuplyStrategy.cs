using System;
using System.Collections.Generic;
using System.Linq;

public class MultuplyStrategy:IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}
