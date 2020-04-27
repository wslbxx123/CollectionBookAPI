using CollectionBookAPI.Core;
using CollectionBookAPI.Core.Settings;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CollectionBookAPI.Infrastructure.Repository
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly IMongoCollection<Bookmark> _bookmarks;

        public BookmarkRepository(IBookmarkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bookmarks = database.GetCollection<Bookmark>(settings.BookmarkCollectionName);
        }

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _bookmarks.InsertOne(bookmark);
            return bookmark;
        }

        public List<Bookmark> GetBookmarks() =>
            _bookmarks.Find(bookmark => true).ToList();
    }
}
