
namespace InventoryManagement.Configuration
{
    public class BlobStorage
    {
        public const string Key = "BlobStorage";
        public string ConnectionString { get; set; }
        public string BaseURI { get; set; }
    }
}
