namespace BashSoft.Repository
{
    using IO;
    using Static_data;
    using System.Collections.Generic;
    using System.Linq;

    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentstoTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(wantedData.OrderBy(x => x.Value.Sum())
                                                .Take(studentstoTake)
                                                .ToDictionary(pair => pair.Key, pair=>pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum())
                                                .Take(studentstoTake)
                                                .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var record in studentsSorted)
            {
                OutputWriter.PrintStudent(record);
            }
        }
    }
}
