namespace PostalService.DAL.Contracts
{
    public interface IPostalDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string PostalCollectionName { get; set; }
    }
}
