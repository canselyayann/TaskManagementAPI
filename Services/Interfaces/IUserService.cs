using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface IUserService
    {
        string Authenticate(string username, string password);
        string GenerateJwtToken(User user);
    }
}
