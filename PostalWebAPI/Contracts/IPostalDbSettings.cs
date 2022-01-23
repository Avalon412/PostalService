using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalWebAPI.Contracts
{
    public interface IPostalDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string PostalCollectionName { get; set; }
    }
}
