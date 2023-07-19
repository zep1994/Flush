using AutoMapper;
using Flush_API.Data;
using Flush_API.Dtos;
using Flush_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Flush_API.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo userRepo, IMapper mapper) 
        {
            _repo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/user/getall")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _repo.GetUsers();
            Console.WriteLine($"{users}");
            return Ok(_mapper.Map<List<User>>(users));
        }

        [HttpPost]
        [Route("api/user/create")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user != null)
            {
                _context.
            }

            return BadRequest("Invalid");

        }

        [HttpGet]
        [Route("api/admin")]
        [Authorize(Roles = "Admin")]
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
