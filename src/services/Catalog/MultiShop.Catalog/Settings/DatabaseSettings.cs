namespace MultiShop.Catalog.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CategoryCollectionName { get; set; } = string.Empty;
        public string ProductCollectionName { get; set; } = string.Empty;
        public string ProductDetailCollectionName { get; set; } = string.Empty;
        public string ProductImageCollectionName { get; set; } = string.Empty;
    }
} 