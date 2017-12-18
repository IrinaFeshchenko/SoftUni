using System.Threading.Tasks;

namespace Teamwork.Services
{
    public interface IPagination
    {
        Task<int> TotalAsync(string searchTerm = "");
    }
}
