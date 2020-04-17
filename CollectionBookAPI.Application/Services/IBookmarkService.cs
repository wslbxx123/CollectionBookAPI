﻿using CollectionBookAPI.Core;
using System;
using System.Collections.Generic;

namespace CollectionBookAPI.Application.Services
{
    public interface IBookmarkService
    {
        List<Bookmark> GetBookmarks();
    }
}
