using CollectionBookAPI.Core;
using CollectionBookAPI.Core.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CollectionBookAPI.Infrastructure.Repository
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly IMongoCollection<Bookmark> _bookmarks;

        public BookmarkRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bookmarks = database.GetCollection<Bookmark>(settings.BookmarkCollectionName);
        }

        public Bookmark AddBookmark(string userId, Bookmark bookmark)
        {
            bookmark.DateUpdated = DateTime.Now;
            bookmark.Owner = userId;

            _bookmarks.InsertOne(bookmark);
            return bookmark;
        }

        public void DeleteBookmark(string userId, string bookmarkId) =>
            _bookmarks.DeleteOne(bookmark => bookmark.Id == bookmarkId && bookmark.Owner == userId);

        public List<Bookmark> GetBookmarks(string userId, DateTime beginTime, int num)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = Builders<Bookmark>.Filter.And(
                Builders<Bookmark>.Filter.Eq("owner", ObjectId.Parse(userId)),
                Builders<Bookmark>.Filter.Lt("dateUpdated", beginTime));

            return _bookmarks.Find(filter)
                .SortByDescending(bookmark => bookmark.DateUpdated)
                .Limit(num)
                .ToList();
        }

        public void UpdateBookmark(string userId, string bookmarkId, Bookmark bookmark)
        {
            bookmark.Id = bookmarkId;
            bookmark.DateUpdated = DateTime.Now;
            _bookmarks.ReplaceOne(bookmark => bookmark.Id == bookmarkId && bookmark.Owner == userId, bookmark);
        }
    }
}
