using CollectionBookAPI.Core;
using System;
using System.Collections.Generic;

namespace CollectionBookAPI.Application.Services
{
    public interface IBookmarkService
    {
        List<Bookmark> GetBookmarks();
        Bookmark AddBookmark(Bookmark bookmark);
        void DeleteBookmark(string id);
        void UpdateBookmark(string id, Bookmark bookmark);
    }
}
