namespace Animals.Models
{
    public abstract class Animal
    {
        public Animal(string name, int age, GenderType gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public enum GenderType
        {
            male,
            female
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }

        public abstract string ProduceSound();

        public string GetAnimalType()
        {
            return this.GetType().Name;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
