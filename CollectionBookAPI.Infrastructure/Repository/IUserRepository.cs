using CollectionBookAPI.Core.Entities;
namespace CollectionBookAPI.Infrastructure.Repository
{
    public interface IUserRepository
    {
        User GetUser(string userName, string password);
    }
}
