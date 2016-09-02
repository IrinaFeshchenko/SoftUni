using System;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode;
        while ((opCode = Console.ReadLine().ToUpper()) != "END")
        {
            string[] codeArgs = opCode.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            long result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        operandOne++;
                        result = operandOne;
                        break;
                    }
                case "DEC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        operandOne--;
                        result = operandOne;
                        break;
                    }
                case "ADD":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        long operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        long operandTwo = long.Parse(codeArgs[2]);
                        result = (long)operandOne * operandTwo;
                        break;
                    }
            }
            Console.WriteLine(result);
        }
    }
}