using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CollectionBookAPI.Core.Entities
{
    public class User
    {
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
