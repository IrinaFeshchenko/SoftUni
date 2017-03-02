namespace _3.Oldest_Family_Member
{
    using _1.Define_a_class_Person;
    using System.Collections.Generic;

    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            int oldest = 0;
            for (int i = 1; i < people.Count; i++)
            {
                if (people[i].Age>people[oldest].Age)
                {
                    oldest = i;
                }
            }

            return people[oldest];
        }
    }
}
