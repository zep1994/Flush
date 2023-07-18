using Flush_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Flush_API.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("api/admin")]
        [Authorize]
        public IActionResult GetAdmin()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.UserName}");
        }

        [HttpGet("Public")]
        [Route("api/user/public")]
        public IActionResult Public()
        {
            return Ok("You are ok here");
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }
    }
}
