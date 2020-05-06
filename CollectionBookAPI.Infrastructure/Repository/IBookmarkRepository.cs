﻿using CollectionBookAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionBookAPI.Infrastructure.Repository
{
    public interface IBookmarkRepository
    {
        List<Bookmark> GetBookmarks();
        Bookmark AddBookmark(Bookmark bookmark);
        void DeleteBookmark(string id);
        void UpdateBookmark(string id, Bookmark bookmark);
    }
}
