using PostalService.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostalService.Services.Contracts
{
    public interface IPackageService
    {
        Task<List<PackageModel>> GetUserPackages(int userId);
        Task<PackageModel> GetPackage(int id);
        Task<List<PackageModel>> GetPackagesByStatus(bool status);
        Task<PackageModel> Create(PackageModel package);
        Task Update(int id, PackageModel package);
        Task Delete(int id);
    }
}
