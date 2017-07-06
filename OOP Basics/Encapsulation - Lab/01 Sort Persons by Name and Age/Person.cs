namespace _01_Sort_Persons_by_Name_and_Age
{
    public class Person
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is a {this.Age} years old";
        }
    }
}
