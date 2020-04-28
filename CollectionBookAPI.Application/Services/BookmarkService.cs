using CollectionBookAPI.Core;
using CollectionBookAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionBookAPI.Application.Services
{
    public class BookmarkService : IBookmarkService
    {
        private IBookmarkRepository _bookmarkRepository;

        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        public Bookmark AddBookmark(Bookmark bookmark) =>
            _bookmarkRepository.AddBookmark(bookmark);

        public void DeleteBookmark(string id) =>
            _bookmarkRepository.DeleteBookmark(id);

        public List<Bookmark> GetBookmarks() =>
            _bookmarkRepository.GetBookmarks();
    }
}
