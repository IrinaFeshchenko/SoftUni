using System.Threading.Tasks;

namespace Teamwork.Services
{
    // Returns only Items that are accessible for the user with that ID
    public interface IFilterablePagination
    {
        Task<int> TotalAsync(string id = null, string searchTerm = "");
    }
}
