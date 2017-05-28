// You are given an empty text.Your task is to implement 4 commands related to manipulating the text
// •	1 someString - appends someString to the end of the text
// •	2 count - erases the last count elements from the text
// •	3 index - returns the element at position index from the text
// •	4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
// Input format: The first line contains n, the number of operations. 
// Each of the following n lines contains the name of the operation followed by the command argument, if any, separated by space in the following format CommandName Argument.
// For example:
// 3
// 1 abc
// 2 2
// 4

namespace _10.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> clipboard =new Stack<string>();
            Stack<int> lastCommand =new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int command = int.Parse(args[0]);

                if (command == 1)
                {
                    clipboard.Push(args[1]);
                    text.Append(clipboard.Peek());

                    lastCommand.Push(command);
                }
                else if (command == 2)
                {
                    int eraseCount = int.Parse(args[1]);
                    int startIndex = text.Length - eraseCount;

                    clipboard.Push(text.ToString(startIndex, eraseCount));
                    text.Remove(startIndex, eraseCount);

                    lastCommand.Push(command);
                }
                else if (command == 3)
                {
                    int index = int.Parse(args[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (command == 4)
                {
                    if (lastCommand.Peek() == 1)
                    {
                        int length = clipboard.Peek().Length;
                        int startIndex = text.Length - length;
                        text.Remove(startIndex, length);
                    }
                    else if (lastCommand.Peek() == 2)
                    {
                        text.Append(clipboard.Peek());
                    }

                    lastCommand.Pop();
                    clipboard.Pop();
                }                
            }
        }
    }
}
