using BookShop.Services.Models.Author;

namespace BookShop.Services
{
    public interface IAuthorService
    {
        AuthorDetailsServiceModel Details(int id);
    }
}
