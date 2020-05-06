using CollectionBookAPI.Core;
using CollectionBookAPI.Core.Settings;
using MongoDB.Driver;
using System;
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
            bookmark.DateUpdated = DateTime.Now;

            // TODO: Get the user ID after authorization.
            bookmark.Owner = "5e97db3c6efef62c58370e5e";

            _bookmarks.InsertOne(bookmark);
            return bookmark;
        }

        public void DeleteBookmark(string id) =>
            _bookmarks.DeleteOne(bookmark => bookmark.Id == id);

        public List<Bookmark> GetBookmarks() =>
            _bookmarks.Find(bookmark => true)
            .SortByDescending(bookmark => bookmark.DateUpdated).ToList();

        public void UpdateBookmark(string id, Bookmark bookmark)
        {
            bookmark.Id = id;
            _bookmarks.ReplaceOne(bookmark => bookmark.Id == id, bookmark);
        }
    }
}
