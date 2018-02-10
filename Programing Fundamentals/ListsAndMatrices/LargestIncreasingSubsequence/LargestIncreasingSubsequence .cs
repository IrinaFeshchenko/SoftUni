namespace Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LargestIncreasingSubsequence
    {
        static void Main()
        {
            // Get all input elements from the console and parse them to integers
            List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            // The working list which will keep all the numbers 
            // and their status during the main cycle
            List<cell> cells = new List<cell>();

            // Load all the input elements in the working list
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                int n = inputNumbers[i];
                cells.Add((new cell(n,i)));
            }

            // Calculating all the data using dynamic optimisation
            // Walking all the elements in the working list in order 
            // of their input and recording the status
            for (int currentNode = 1; currentNode < cells.Count; currentNode++)
            {
                // get the index of the longest sequence element found on left of curent element
                int longestSequence = GetLongestSequence(cells, currentNode);

                // If we find such element, make our element part of that sequence 
                //and set the current element count/status
                if (longestSequence!=-1)
                {
                    cells[currentNode].PreviousNode = longestSequence;
                    cells[currentNode].Count += cells[longestSequence].Count;
                }
            }

            // Use the calculated data to get the element that 
            // has the highest status/count and get its index
            int node = cells
                        .Where(x => x.Count == cells
                                     .Select(y => y.Count)
                                     .Max())
                        .Select(z=>z.Index)
                        .FirstOrDefault();                                      


            // The stact that will reverse the order of the result sequence
            Stack<int> stack = new Stack<int>();

            // As walking the resulted linked list will give us the sequence in reverse order,
            // we put all elements in a stack, so we can get them bak in the right order
            do
            {
                stack.Push(cells[node].Value);
                node = cells[node].PreviousNode;
            }
            while (node != -1);

            // Print the resust sequence on the console
            Console.WriteLine( string.Join(" ",stack));
        }

        // cells - parameter is reference to the working list
        // nodePosition - parameter is the current element index in the original input sequence
        // Returns - index of the result element
        private static int GetLongestSequence(List<cell> cells, int nodePosition)
        {
            int longestSequence = -1;
            int maxCount = 0;

            // Walk all elements located on the left of the current element and
            // get a smaller one that has the highest count/status (is part of the longest sequence)
            for (int currentPosition = 0; currentPosition < nodePosition; currentPosition++)
            {
                if (cells[currentPosition].Value < cells[nodePosition].Value &&
                    cells[currentPosition].Count > maxCount)
                {
                    longestSequence = currentPosition;
                    maxCount = cells[currentPosition].Count;
                }
            }

            // The index of the result element
            return longestSequence;
        }

        // Helper class to hold all data for the elements, required for the dinamic optimisation
        public class cell
        {
            // value - parameter is the value of the element
            // index - parameter is the index of the element in the original input sequence
            public cell(int value, int index)
            {
                Value = value;
                Count = 1;
                PreviousNode = -1;
                Index = index;
            }

            // The numerical value of the curent element
            public int Value { get; set; }

            // The status of the current element (lenght of the increasing sequence it is part of)
            public int Count { get; set; }

            // The index ot the previous node which is part of the increasing sequence
            public int PreviousNode { get; set; }

            // The index of the curent element in the original input sequence
            public int Index { get; set; }
        }
    }
}