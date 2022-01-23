using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using PostalWebAPI.Contracts;
using PostalWebAPI.Models;

namespace PostalWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserRepository(IPostalDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<UserModel>(settings.PostalCollectionName);
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
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
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
