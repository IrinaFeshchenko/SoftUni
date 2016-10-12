namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class Town
    {
        public Town()
        {
            this.Students = new List<Student>();
        }
        public string Name { get; set; }
        public int SeatsPerGroup { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        public Group(Town inputTown)
        {
            this.Students = new List<Student>();
            this.Town = inputTown;
        }
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Start
    {
        public static void Main()
        {
            var towns = ParseInput();
            var groups = CreateGroups(towns);
            PrintResult(groups, towns);
        }

        private static void PrintResult(IList<Group> groups, IList<Town> towns)
        {

            Console.WriteLine($"Created {groups.Count} groups in {towns.Distinct().Count()} towns:");
            var sortedGroups = groups.OrderBy(x=>x.Town.Name);

            foreach (var group in sortedGroups)
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ",group.Students.Select(x=>x.Email))}");
            }
        }

        private static IList<Group> CreateGroups(IList<Town> towns)
        {
            var groups = new List<Group>();
            towns = towns.OrderBy(x => x.Name).ToList();

            foreach (var town in towns)
            {
                IEnumerable<Student> students = town.Students.OrderBy(x => x.RegistrationDate)
                                             .ThenBy(x => x.Name)
                                             .ThenBy(x=>x.Email);          

                while (students.Any())
                {
                    var group = new Group(town);
                    group.Students = students.Take(group.Town.SeatsPerGroup).ToList();
                    students = students.Skip(group.Town.SeatsPerGroup);
                    groups.Add(group);
                }
            }

            return groups;
       }

        private static IList<Town> ParseInput()
        {
            var towns = new List<Town>();
            var town = new Town();

            while (true)
            {
                string line = Console.ReadLine();

                if (line.ToLower() == "end")
                {
                    break;
                }

                string townsMarker = "=>";
                if (line.Contains(townsMarker))
                {
                    if (town.Students.Any())
                    {
                        towns.Add(town);
                        town = new Town();
                    }
                    var parts = line.Split(new[] { townsMarker }, StringSplitOptions.RemoveEmptyEntries);
                    town.Name = parts[0].Trim();
                    town.SeatsPerGroup = int.Parse(parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    continue;
                }

                var args = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var student = new Student();
                student.Name = args[0].Trim();
                student.Email = args[1].Trim();
                student.RegistrationDate = DateTime.ParseExact(args[2].Trim(),"d-MMM-yyyy",CultureInfo.InvariantCulture);
                town.Students.Add(student);
            }

            if (town.Students.Any())
            {
                towns.Add(town);
            }

            return towns;
        }
    }
}
