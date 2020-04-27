using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionBookAPI.Application.Services;
using CollectionBookAPI.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectionBookAPI.Controllers
{
    [Route("api/[controller]")]
    public class BookmarkController : Controller
    {
        private IBookmarkService _service;

        public BookmarkController(IBookmarkService service)
        {
            this._service = service;
        }

        [HttpGet("[action]")]
        // GET: Bookmark
        public IActionResult GetBookmarks()
        {
            try
            {
                var bookmarks = _service.GetBookmarks();
                return Ok(bookmarks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("[action]")]
        public IActionResult AddBookmark([FromBody] Bookmark bookmark)
        {
            try
            {
                var bookmarks = _service.AddBookmark(bookmark);
                return Ok(bookmarks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}