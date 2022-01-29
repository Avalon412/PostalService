using Microsoft.AspNetCore.Mvc;
using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        /// <summary>
        /// Gets all packages for specified user
        /// </summary>
        [HttpGet("userPackages/{userId}")]
        public async Task<ActionResult<List<PackageModel>>> GetUserPackages(int userId)
        {
            var packages = await _packageService.GetUserPackages(userId);

            if (!packages.Any())
            {
                return NotFound();
            }

            return packages;
        }

        /// <summary>
        /// Gets package by Id
        /// </summary>
        [HttpGet("packages/{packageId}")]
        public async Task<ActionResult<PackageModel>> GetPackage(int packageId)
        {
            var package = await _packageService.GetPackage(packageId);

            if (package is null)
            {
                return NotFound();
            }

            return package;
        }

        /// <summary>
        /// Creates new package
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreatePackage(PackageModel package)
        {
            await _packageService.Create(package);

            return CreatedAtAction(nameof(CreatePackage), new { id = package.Id }, package);
        }

        /// <summary>
        /// Updates existing package info
        /// </summary>
        [HttpPut("{packageId}")]
        public async Task<IActionResult> UpdatePackage(int packageId, PackageModel package)
        {
            var existingPackage = await _packageService.GetPackage(packageId);

            if (existingPackage is null)
            {
                return NotFound();
            }

            await _packageService.Update(packageId, package);

            return NoContent();
        }

        /// <summary>
        /// Deletes existing package
        /// </summary>
        [HttpDelete("{packageId}")]
        public async Task<IActionResult> DeletePackage(int packageId)
        {
            var existingPackage = await _packageService.GetPackage(packageId);

            if (existingPackage is null)
            {
                return NotFound();
            }

            await _packageService.Delete(packageId);

            return NoContent();
        }
    }
}
