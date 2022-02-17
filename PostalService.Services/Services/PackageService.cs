using PostalService.DAL.Contracts;
using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Services.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<PackageModel> GetPackage(int id)
        {
            return await _packageRepository.GetPackage(id);
        }

        public async Task<List<PackageModel>> GetUserPackages(int userId)
        {
            return await _packageRepository.GetUserPackages(userId);
        }

        public async Task<List<PackageModel>> GetPackagesByStatus(bool status)
        {
            return await _packageRepository.GetPackagesByStatus(status);
        }

        public async Task<PackageModel> Create(PackageModel package)
        {
            return await _packageRepository.Create(package);
        }

        public async Task Update(PackageModel package)
        {
            await _packageRepository.Update(package);
        }
        public async Task Delete(PackageModel package)
        {
            await _packageRepository.Delete(package);
        }
    }
}
