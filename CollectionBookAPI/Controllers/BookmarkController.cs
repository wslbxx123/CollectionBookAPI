using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionBookAPI.Application.Services;
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

        // GET: Bookmark/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Bookmark/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Bookmark/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Bookmark/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Bookmark/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Bookmark/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Bookmark/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}