using MongoDB.Driver;
using PostalService.DAL.Contracts;
using PostalService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DAL.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly IMongoCollection<PackageModel> _packages;

        public PackageRepository(IPostalDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _packages = database.GetCollection<PackageModel>(PostalCollections.Packages.ToString());
        }

        public async Task<PackageModel> GetPackage(int id)
        {
            return await _packages.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PackageModel>> GetUserPackages(int userId)
        {
            return await _packages.Find(u => u.UserId == userId).ToListAsync();
        }

        public async Task<PackageModel> Create(PackageModel package)
        {
            await _packages.InsertOneAsync(package);
            return package;
        }

        public async Task Update(int id, PackageModel package)
        {
            await _packages.ReplaceOneAsync(p => p.Id == id, package);
        }

        public async Task Delete(int id)
        {
            await _packages.DeleteOneAsync(p => p.Id == id);
        }
    }
}
