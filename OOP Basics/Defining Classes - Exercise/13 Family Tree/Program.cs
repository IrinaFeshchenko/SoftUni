using System;
namespace _13_Family_Tree
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            // input
            Person mainPerson = new Person();
            string nameOrDate = InputParser.ParseFirstInput(mainPerson);
            List<Record> records = InputParser.ParseAllData();

            if (nameOrDate == "date")
            {
                mainPerson.Name = records.Where(r => r.right == mainPerson.BirthDate && r.version == RecordVersion.v5).FirstOrDefault().left;
            }
            else if (nameOrDate == "name")
            {
                mainPerson.BirthDate = records.Where(r => r.left == mainPerson.Name && r.version == RecordVersion.v5).FirstOrDefault().right;

            }
            
            // match records data
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

            // output
            Console.WriteLine($"{mainPerson.Name} {mainPerson.BirthDate}");

            Console.WriteLine("Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent.left} {parent.right}");
            }

            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.left} {child.right}");
            }
        }
    }
}
