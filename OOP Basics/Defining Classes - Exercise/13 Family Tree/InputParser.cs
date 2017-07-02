
namespace _13_Family_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public static class InputParser
    {
        public static List<Record> ParseAllData()
        {
            List<Record> records = new List<Record>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                var record = GetRecord(input);
                records.Add(record);
            }

            return records;
        }

        private static Record GetRecord(string input)
        {
            Record record = new Record();

            string patternV1 = @"([A-Za-z]+\s+[A-Za-z]+)\s+-\s+([A-Za-z]+\s+[A-Za-z]+)";
            string patternV2 = @"([A-Za-z]+\s+[A-Za-z]+)\s+-\s+(\d{1,2}\/\d{1,2}\/\d{4})";
            string patternV3 = @"(\d{1,2}\/\d{1,2}\/\d{4})\s+-\s+([A-Za-z]+\s+[A-Za-z]+)";
            string patternV4 = @"(\d{1,2}\/\d{1,2}\/\d{4})\s+-\s+(\d{1,2}\/\d{1,2}\/\d{4})";
            string patternV5 = @"([A-Za-z]+\s+[A-Za-z]+)\s+(\d{1,2}\/\d{1,2}\/\d{4})";

            if (Regex.IsMatch(input, patternV1))
            {
                var match = Regex.Match(input, patternV1);
                record.left = match.Groups[1].Value;
                record.right = match.Groups[2].Value;
                record.version = RecordVersion.v1;

                return record;
            }
            else if (Regex.IsMatch(input, patternV2))
            {
                var match = Regex.Match(input, patternV2);
                record.left = match.Groups[1].Value;
                record.right = match.Groups[2].Value;
                record.version = RecordVersion.v2;

                return record;
            }
            else if (Regex.IsMatch(input, patternV3))
            {
                var match = Regex.Match(input, patternV3);
                record.left = match.Groups[1].Value;
                record.right = match.Groups[2].Value;
                record.version = RecordVersion.v3;

                return record;
            }
            else if (Regex.IsMatch(input, patternV4))
            {
                var match = Regex.Match(input, patternV4);
                record.left = match.Groups[1].Value;
                record.right = match.Groups[2].Value;
                record.version = RecordVersion.v4;

                return record;
            }
            else if (Regex.IsMatch(input, patternV5))
            {
                var match = Regex.Match(input, patternV5);
                record.left = match.Groups[1].Value;
                record.right = match.Groups[2].Value;
                record.version = RecordVersion.v5;

                return record;
            }
            else
            {
                throw new Exception("Recoord parse fail");
            }
        }

        public static Person ParseFirstInput()
        {
            var mainPerson = new Person();
            string firstInput = Console.ReadLine();

            if (char.IsDigit(firstInput[0]))
            {
                mainPerson.BirthDate = firstInput;
            }
            else
            {
                mainPerson.Name = firstInput;
            }

            return mainPerson;
        }
    }
}
