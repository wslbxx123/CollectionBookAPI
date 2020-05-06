using CollectionBookAPI.Core.Entities;
using System.Collections.Generic;

namespace CollectionBookAPI.Application.Services
{
    public interface IUserService
    {
        User Authenticate(string userName, string password);
    }
}
