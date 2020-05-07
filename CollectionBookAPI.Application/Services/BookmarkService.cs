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

        public Bookmark AddBookmark(string userId, Bookmark bookmark) =>
            _bookmarkRepository.AddBookmark(userId, bookmark);

        public void DeleteBookmark(string userId, string bookmarkId) =>
            _bookmarkRepository.DeleteBookmark(userId, bookmarkId);

        public List<Bookmark> GetBookmarks(string userId, DateTime beginTime, int num) =>
            _bookmarkRepository.GetBookmarks(userId, beginTime, num);

        public void UpdateBookmark(string userId, string bookmarkId, Bookmark bookmark) =>
            _bookmarkRepository.UpdateBookmark(userId, bookmarkId, bookmark);
    }
}
