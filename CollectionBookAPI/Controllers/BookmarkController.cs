using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CollectionBookAPI.Application.Services;
using CollectionBookAPI.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollectionBookAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BookmarkController : Controller
    {
        private IBookmarkService _service;

        public BookmarkController(IBookmarkService service)
        {
            this._service = service;
        }

        [HttpGet("GetBookmarks")]
        public IActionResult GetBookmarks(DateTime? beginTime, int num = 10)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var bookmarks = _service.GetBookmarks(userId, beginTime == null ? DateTime.MaxValue : (DateTime)beginTime, num);
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
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var bookmarks = _service.AddBookmark(userId, bookmark);
                return Ok(bookmarks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBookmark/{id}")]
        public IActionResult DeleteBookmark(string id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _service.DeleteBookmark(userId, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBookmark/{id}")]
        public IActionResult UpdateBookmark(string id, [FromBody] Bookmark bookmark)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _service.UpdateBookmark(userId,  id, bookmark);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}