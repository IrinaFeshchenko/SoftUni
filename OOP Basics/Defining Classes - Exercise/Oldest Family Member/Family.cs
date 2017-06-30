
namespace Oldest_Family_Member
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        private List<Person> People { get; set; }

        public void AddMember(Person memeber)
        {
            this.People.Add(memeber);
        }

        public Person GetOldestMember()
        {
            var oldestMember = People.Where(x => 
                                       x.age == People.Select(p => p.age).Max())
                                       .FirstOrDefault();
            return oldestMember;
        }
    }
}
