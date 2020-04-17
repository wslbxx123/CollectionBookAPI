using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionBookAPI.Core.Settings
{
    public class BookmarkDatabaseSettings : IBookmarkDatabaseSettings
    {
        public string BookmarkCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
