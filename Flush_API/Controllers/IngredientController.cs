using AutoMapper;
using Flush_API.Data;
using Flush_API.Dtos;
using Flush_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Flush_API.Controllers
{
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepo _repo;
        private readonly IMapper _mapper;
        private readonly object _client;
        static HttpClient client = new HttpClient();


        public IngredientController(IIngredientRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: IngredientController
        [HttpGet("api/ingredients")]
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/ingredient/{ingredient}")]
        public async Task<ActionResult<IEnumerable<IngredientReadDto>>> GetIngredient(string ingredient)
        {
            var path = $"https://api.spoonacular.com/food/ingredients/search?apiKey={API_KEY}&query={ingredient}";
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            var response = client.SendAsync(request).Result;
            var stringResponse = await response.Content.ReadAsStringAsync();
            return Ok(stringResponse);
        }

    }
}
