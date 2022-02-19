using PostalService.DAL.Contracts;
using PostalService.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DAL.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly PostalDbContext _dbContext;

        public PackageRepository(PostalDbContext context)
        {
            _dbContext = context;
        }

        public async Task<PackageModel> GetPackage(int id)
        {
            return await _dbContext.Packages.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PackageModel>> GetUserPackages(int userId)
        {
            return await _dbContext.Packages.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<List<PackageModel>> GetPackagesByStatus(bool status)
        {
            return await _dbContext.Packages.Where(p => p.IsReceived == status).ToListAsync();
        }

        public async Task<PackageModel> Create(PackageModel package)
        {
            _dbContext.Packages.Add(package);
            await _dbContext.SaveChangesAsync();
            return package;
        }

        public async Task Update(PackageModel package)
        {
            _dbContext.Packages.Update(package);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(PackageModel package)
        {
            _dbContext.Packages.Remove(package);
            await _dbContext.SaveChangesAsync();
        }
    }
}
