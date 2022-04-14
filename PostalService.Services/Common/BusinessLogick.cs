using PostalService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Services.Common
{
    public class BusinessLogick
    {
        public PackageModel _package;

        public BusinessLogick(PackageModel package)
        {
            _package = package;
        }

        public void DoSomeAction()
        {
            _package.Id *= 1000;
        }
    }
}
