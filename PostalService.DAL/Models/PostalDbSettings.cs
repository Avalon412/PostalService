using PostalService.DAL.Contracts;

namespace PostalService.DAL.Models
{
    public class PostalDbSettings : IPostalDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string PostalCollectionName { get; set; }
    }
}
