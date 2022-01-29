using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PostalService.DAL.Contracts;
using PostalService.DAL.Models;

namespace PostalService.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> _users;
        private readonly IMongoCollection<PackageModel> _packages;

        public UserRepository(IPostalDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<UserModel>(PostalCollections.Users.ToString());
            _packages = database.GetCollection<PackageModel>(PostalCollections.Packages.ToString());
        }

        public async Task<UserModel> Create(UserModel user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<List<UserModel>> Get()
        {
            return await _users.Find(user => true).ToListAsync();
        }

        public async Task<UserModel> Get(int id)
        {
            var user = await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
            user.Packages = await _packages.Find(p => p.UserId == user.Id).ToListAsync();
            return user;
        }

        public async Task Remove(int id)
        {
            await _users.DeleteOneAsync(user => user.Id == id);
        }

        public async Task Update(int id, UserModel user)
        {
            await _users.ReplaceOneAsync(user => user.Id == id, user);
        }
    }
}
