namespace _14_Cat_Lady
{
    public class StreetExtraordinaire : CatType
    {
        public StreetExtraordinaire(string breed, string name, string param) : base(breed, name, param)
        {
        }

        public override string ToString()
        {
            return $"{this.Breed} {this.Name} {double.Parse(this.Param)}";
        }
    }
}
