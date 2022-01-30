using PostalService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.DAL.Contracts
{
    public interface IPackageRepository
    {
        Task<List<PackageModel>> GetUserPackages(int userId);
        Task<List<PackageModel>> GetPackagesByStatus(bool status);
        Task<PackageModel> GetPackage(int id);
        Task<PackageModel> Create(PackageModel package);
        Task Update(int id, PackageModel package);
        Task Delete(int id);
    }
}
