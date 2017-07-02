using System;
namespace _13_Family_Tree
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        private static string firtsName;

        static void Main()
        {
            // input
            var mainPerson = InputParser.ParseFirstInput();
            List<Record> records = InputParser.ParseAllData();

            if (string.IsNullOrEmpty(mainPerson.Name))
            {
                mainPerson.Name = records.Where(r => r.right == mainPerson.BirthDate && r.version == RecordVersion.v5).FirstOrDefault().left;
            }
            else
            {
                mainPerson.BirthDate = records.Where(r => r.left == mainPerson.Name && r.version == RecordVersion.v5).FirstOrDefault().right;
            }

            // output
            Console.WriteLine($"{mainPerson.Name} {mainPerson.BirthDate}");

            foreach (var record in records)
            {
                if (RecordsHelper.IsParent(records, record, mainPerson, out Record resultParentRecord))
                {
                    mainPerson.AddPrent(resultParentRecord);
                }

                if (RecordsHelper.IsChildren(records, record, mainPerson, out Record resultChildrenRecord))
                {
                    mainPerson.AddChild(resultChildrenRecord);
                }
            }
            ;
        }
    }
}
