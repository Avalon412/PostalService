using PostalService.DAL.Contracts;
using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using PostalService.Services.Common;

namespace PostalService.Services.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly ILogger _logger;
        private readonly IValidator _validator;
        private readonly IBusinessLogick _businessLogick;

        public PackageService(IPackageRepository packageRepository, ILogger logger, IValidator validator, IBusinessLogick businessLogick)
        {
            _packageRepository = packageRepository;
            _logger = logger;
            _validator = validator;
            _businessLogick = businessLogick;
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
            if (package is null)
            {
                throw new NullReferenceException();
            }

            if (_validator.Validate(package, _logger))
            {
                _businessLogick.DoSomeAction();
                return package;
            }
            else
            {
                return null;
            }

            var listOfDuplicatedPackaged = new List<PackageModel> { package, package, package, package, package, package };
            int i = 1;
            foreach (var item in listOfDuplicatedPackaged)
            {
                item.Id += 200 * i++;
            }

            return await _packageRepository.Create(package);
        }

        public async Task Update(PackageModel package)
        {
            if (package is null)
            {
                throw new NullReferenceException();
            }

            if (_validator.Validate(package, _logger))
            {
                var bl = new BusinessLogick(package);
                bl.DoSomeAction();
            }

            var listOfDuplicatedPackaged = new List<PackageModel> { package, package, package, package, package, package };
            int i = 1;
            foreach (var item in listOfDuplicatedPackaged)
            {
                item.Id += 200 * i++;
            }

            await _packageRepository.Update(package);
        }

        public async Task Delete(PackageModel package)
        {
            await _packageRepository.Delete(package);
        }
    }
}
