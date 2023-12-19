namespace mongodb_dotnet_example.Models
{
    public class ProductsDatabaseSettings : IProductsDatabaseSettings
	{
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductsDatabaseSettings
    {
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}