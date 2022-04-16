using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Services.Common
{
    public class Validator : IValidator
    {
        public bool IsRequired { get; set; }

        public bool Validate(PackageModel package, ILogger logger)
        {
            if (package.Id < 0)
            {
                logger.Error($"Id of a package was less than zero: {package.Id}");
                return false;
            }

            if (package.UserId < 0)
            {
                logger.Error($"Id of a user was less than zero: {package.UserId}");
                return false;
            }

            return true;
        }
    }
}
