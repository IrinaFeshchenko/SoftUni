using System.Collections.Generic;

class PrimitiveCalculator
{
    private IStrategy strategy;

    private Dictionary<char, IStrategy> strategies;

    public PrimitiveCalculator()
    {
        this.strategies = new Dictionary<char, IStrategy>()
                              {
                                  {'+',new AdditionStrategy() },
                                  {'-',new SubtractionStrategy() },
                                  {'*',new MultuplyStrategy() },
                                  {'/',new DivideStrategy() },
                              };

        this.strategy = this.strategies['+'];
    }

    public void ChangeStrategy(char @operator)
    {
        this.strategy = this.strategies[@operator];
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}

