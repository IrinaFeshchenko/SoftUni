namespace _14_Cat_Lady
{
    public class Cymric : CatType
    {
        public Cymric(string breed, string name, string param) : base(breed, name, param)
        {
        }

        public override string ToString()
        {
            return $"{this.Breed} {this.Name} {double.Parse(this.Param):F2}";
        }
    }
}
