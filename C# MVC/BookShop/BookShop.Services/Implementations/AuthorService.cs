using BookShop.Services.Models.Author;
using BookShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

    }
}
