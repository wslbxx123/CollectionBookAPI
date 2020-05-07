using CollectionBookAPI.Application.Services;
using CollectionBookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CollectionBookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

 
        [HttpPost]
        public IActionResult Login([FromBody]UserModel login)
        {
            if(login == null)
                return BadRequest(new { message = "Please input user name and password" });

            var user = _userService.Authenticate(login.UserName, login.Password);

            if (user == null)
                return BadRequest(new { message = "User name or password is incorrect" });

            return Ok(user);
        }
    }
}
