namespace CollectionBookAPI.Core.Settings
{
    public interface IDatabaseSettings
    {
        public string BookmarkCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
