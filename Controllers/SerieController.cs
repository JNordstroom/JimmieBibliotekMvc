using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.mvc.Data;
using MyLibrary.mvc.ViewModels;

namespace MyLibrary.mvc.Controllers
{
    [Route("Series")]
    public class SerieController : Controller
    {
        private readonly MyLibraryContext _context;
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _httpClient;
        private readonly string _baseUrl;

        public SerieController(MyLibraryContext context, IConfiguration config, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = config.GetSection("apiSettings:baseUrl").Value;
            _context = context;
            _options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
        }

        [HttpGet("list")]
        public async Task<IActionResult> Index()
        {
            using var client = _httpClient.CreateClient();

            var response = await client.GetAsync($"{_baseUrl}/series");

            if(!response.IsSuccessStatusCode) return Content("Något gick fel!");

            var json  = await response.Content.ReadAsStringAsync();

            var movies = JsonSerializer.Deserialize<IList<SerieListViewModel>>(json, _options);

            return View("Index", movies);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> SerieById(int id)
        {
            using var client = _httpClient.CreateClient();

            var response = await client.GetAsync($"{_baseUrl}/series/{id}");

            if(!response.IsSuccessStatusCode) return Content("Något gick fel!");

            var json  = await response.Content.ReadAsStringAsync();

            var serieDetails = JsonSerializer.Deserialize<SerieDetailsViewModel>(json, _options);

            return View("Details", serieDetails);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            var serie = new SeriePostViewModel();
            return View("Create", serie);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(SeriePostViewModel serie)
        {
            var client = _httpClient.CreateClient();

            var response = await client.PostAsJsonAsync($"{_baseUrl}/series", serie);

            
            if(!response.IsSuccessStatusCode) return BadRequest("Felaktig inmatning!");
            

            return RedirectToAction("Index");
        }
    }
}