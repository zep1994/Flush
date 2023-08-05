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
        private readonly AppDbContext _context;


        public UsersController(IUserRepo userRepo, IMapper mapper, AppDbContext context)
        {
            _repo = userRepo;
            _mapper = mapper;
            _context = context;
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
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is empty.");
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            // Return a success response.
            return Ok("User registered successfully.");

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
