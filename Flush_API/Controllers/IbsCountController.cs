using AutoMapper;
using Flush_API.Data;
using Flush_API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Flush_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IbsCountController : ControllerBase
    {

        private readonly IIbsCountRepo _repo;
        private readonly IMapper _mapper;

        public IbsCountController(IIbsCountRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IbsCountReadDto>>> GetAllIbsCounts()
        {
            var count = await _repo.GetAllIbsCounts();
            Console.WriteLine($"{count}");
            return Ok(_mapper.Map<IEnumerable<IbsCountReadDto>>(count));
        }
    }
}
