using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionBookAPI.Core.Settings
{
    public interface IAppSettings
    {
        public string Secret { get; set; }
    }
}
