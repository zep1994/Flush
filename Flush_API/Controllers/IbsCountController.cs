using AutoMapper;
using Flush_API.Data;
using Flush_API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<IbsCountReadDto>>> GetIbsCountById(int id)
        {
            var ibsCountModel = await _repo.GetIbsCountById(id);
            if (ibsCountModel != null)
            {
                return Ok(_mapper.Map<IbsCountReadDto>(ibsCountModel));
            }
            return NotFound();
        }
    }
}
