
namespace Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System.Data.Entity;
    using System.Linq;

    public class TownService
    {
        public void AddTown(string townName, string country)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                context.Towns.Add(town);
                context.SaveChanges();              
            }
        }

        public bool IsTownExisting(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

        public Town GetTownBytownName(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name == townName);
            }
        }
    }
}
