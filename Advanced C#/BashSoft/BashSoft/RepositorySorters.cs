namespace BashSoft
{
    using System;
    using System.Collections.Generic;

    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentstoTake)
        {

        }
        private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentstoTake, 
            Func<KeyValuePair<string,List<int>>, KeyValuePair<string, List<int>>,int> comparisonFunc)
        {

        }

        private static int CompareInOrder(KeyValuePair<string,List<int>> firstValue, KeyValuePair<string,List<int>> secondValue)
        {
            int totalOfFirstMarks = 0;
            foreach (var mark in firstValue.Value)
            {
                totalOfFirstMarks += mark;
            }

            int totalOfSecondMarks = 0;
            foreach (var mark in secondValue.Value)
            {
                totalOfSecondMarks += mark;
            }

            return totalOfSecondMarks.CompareTo(totalOfFirstMarks);
        }

        private static int CompareDescendingOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        {
            int totalOfFirstMarks = 0;
            foreach (var mark in firstValue.Value)
            {
                totalOfFirstMarks += mark;
            }

            int totalOfSecondMarks = 0;
            foreach (var mark in secondValue.Value)
            {
                totalOfSecondMarks += mark;
            }

            return totalOfFirstMarks.CompareTo(totalOfSecondMarks);
        }
    }
}
