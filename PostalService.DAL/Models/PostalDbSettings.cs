using PostalService.DAL.Contracts;

namespace PostalService.DAL.Models
{
    public enum PostalCollections
    {
        Users,
        Packages
    }

    public class PostalDbSettings : IPostalDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
