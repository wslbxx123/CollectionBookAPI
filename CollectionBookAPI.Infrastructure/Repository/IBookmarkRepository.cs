using CollectionBookAPI.Core;
using System;
using System.Collections.Generic;

namespace CollectionBookAPI.Infrastructure.Repository
{
    public interface IBookmarkRepository
    {
        List<Bookmark> GetBookmarks(string userId, DateTime beginTime, int num);
        Bookmark AddBookmark(string userId, Bookmark bookmark);
        void DeleteBookmark(string userId, string bookmarkId);
        void UpdateBookmark(string userId, string bookmarkId, Bookmark bookmark);
    }
}
