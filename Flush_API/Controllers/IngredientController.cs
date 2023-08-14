using AutoMapper;
using Flush_API.Data;
using Flush_API.Dtos;
using Flush_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace Flush_API.Controllers
{
    [ApiController]
    public class IngredientController : ControllerBase
    {

        private const string ApiUrl = "https://api.spoonacular.com/food/ingredients/search?apiKey=0bb23cf0a7f64e77b02f60042af49ecf&query={0}";

        private readonly IHttpClientFactory _httpClientFactory;

        public IngredientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: IngredientController
        [HttpGet("api/ingredients")]
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/ingredients/{ingredient}")]
        public async Task<IActionResult> GetIngredientInfo(string ingredient)
        {
            //var path = $"https://api.spoonacular.com/food/ingredients/search?apiKey=0bb23cf0a7f64e77b02f60042af49ecf&query={ingredient}";
            //var request = new HttpRequestMessage(HttpMethod.Get, path);
            //var response = client.SendAsync(request).Result;
            //var stringResponse = await response.Content.ReadAsStringAsync();
            //return Ok(stringResponse);
            if (string.IsNullOrWhiteSpace(ingredient))
            {
                return BadRequest("Ingredient is required.");
            }

            try
            {
                var formattedApiUrl = string.Format(ApiUrl, Uri.EscapeDataString(ingredient));
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync(formattedApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return Content(jsonResponse, "application/json");
                }
                else
                {
                    return BadRequest("Failed to fetch ingredient information from Spoonacular API.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
