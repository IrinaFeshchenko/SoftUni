
namespace _14_Cat_Lady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            Dictionary<string, CatType> cats = new Dictionary<string, CatType>();
            while (true)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (args[0] == "End") break;

                var breed = args[0];
                var name = args[1];
                var param = args[2];

                if (breed == "Cymric")
                {
                    var cat = new Cymric(breed, name, param);
                    cats.Add(name, cat);
                }
                else if (breed =="Siamese")
                {
                    var cat = new Siamese(breed, name, param);
                    cats.Add(name, cat);
                }
                else if (breed == "StreetExtraordinaire")
                {
                    var cat = new StreetExtraordinaire(breed, name, param);
                    cats.Add(name, cat);
                }
            }

            string filter = Console.ReadLine();

            var result = cats.Where(c => c.Key == filter).FirstOrDefault().Value;

            Console.WriteLine(result.ToString());
            ;
        }
    }
}
