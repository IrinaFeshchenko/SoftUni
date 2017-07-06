namespace _14_Cat_Lady
{
    public abstract class CatType
    {
        public CatType(string breed, string name, string param)
        {
            Breed = breed;
            Name = name;
            Param = param;
        }

        public string Breed { get; set; }
        public string Name { get; set; }
        public string Param { get; set; }
    }
}
