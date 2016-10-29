using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JediDreams;

namespace JediDreams.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExtractMethodsShouldReturnMethods()
        {
            //arrange
            int n = 46;
            string inputText = @"static void InitPatterns(List<bool[,]> patterns)
        {
            // zero
            patterns.Add(new bool[,]
            {
                //TODO
            });

            // one
            patterns.Add(new bool[,]
            {
                //TODO
            });
        }

        static bool CheckCurrentPattern(int[,] numbers , bool[,] pattern , int row , int col , int digit)
        {
            for(int i = 0; i < pattern.GetLength(0); i++)
            {
                for(int j = 0; j < pattern.GetLength(1); j++)
                {
                    //TODO
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] numbers = new int[n , n];

            for(int i = 0; i < n; i++)
            {
                var currentNumbers = Console.ReadLine().Split(' ')

                for(int j = 0; j < currentNumbers.Length; j++)
                {
                    numbers[i , j] = int.Parse(currentNumbers[j]);
                }
            }

            List<bool[,]> patterns = new List<bool[,]>();
            InitPatterns(patterns);";

            string[] lines = Console.ReadLine().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<string> input = new List<string>();
            foreach (var line in lines)
            {
              //  input.Add(inputText[n]);
            }

            //act
            var res = Start.ExtractMethods(input);
            //assert
           // Assert();
        }
    }
}
