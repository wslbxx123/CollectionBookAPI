using CollectionBookAPI.Core.Entities;
using CollectionBookAPI.Core.Settings;
using MongoDB.Driver;

namespace CollectionBookAPI.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public User GetUser(string userName, string password) =>
            _users.Find(user => user.UserName.ToLower() == userName.ToLower() && user.Password == password).FirstOrDefault();
    }
}
