using BookShop.Service.Models.Author;
using BookShop.Database;
using System.Linq;
using AutoMapper.QueryableExtensions;
using BookShop.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookShop.Service.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
        {
            return await this.db
                .Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefaultAsync();
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.db.Authors.Add(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }
    }
}
