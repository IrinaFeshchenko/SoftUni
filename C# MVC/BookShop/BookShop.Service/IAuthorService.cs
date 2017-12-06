using BookShop.Service.Models.Author;
using System.Threading.Tasks;

namespace BookShop.Service
{
    public interface IAuthorService
    {
        Task<AuthorDetailsServiceModel> Details(int id);

        Task<int> Create(string firstName, string lastName);
    }
}
