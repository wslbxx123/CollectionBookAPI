using CollectionBookAPI.Core.Entities;

namespace CollectionBookAPI.Application.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
