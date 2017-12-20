using System.Threading.Tasks;

namespace Teamwork.Services
{
    public interface IFilterablePagination
    {
        Task<int> TotalAsync(string id = null, string searchTerm = "");
    }
}
