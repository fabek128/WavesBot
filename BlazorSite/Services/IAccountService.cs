using System.Threading.Tasks;

namespace BlazorSite.Services
{
    public interface IAccountService
    {
        Task<string> GenerateRandomSeed();
        Task<string> GetSeed();
    }
}