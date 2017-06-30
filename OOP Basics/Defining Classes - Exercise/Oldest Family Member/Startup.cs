
namespace Oldest_Family_Member
{
    using System;
    using System.Reflection;

    class Startup
    {
        static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int n = int.Parse(Console.ReadLine());

            var family = new Family();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var familyMember = new Person(name,age);
                family.AddMember(familyMember);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
