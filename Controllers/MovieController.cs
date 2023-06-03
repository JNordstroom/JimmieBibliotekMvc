using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.mvc.Data;
using MyLibrary.mvc.ViewModels;

namespace MyLibrary.mvc.Controllers;

[Route("movies")]
public class MovieController : Controller
{
    private readonly MyLibraryContext _context;
    private readonly JsonSerializerOptions _options;
    private readonly IHttpClientFactory _httpClient;
    private readonly string _baseUrl;

    public MovieController(MyLibraryContext context, IConfiguration config, IHttpClientFactory httpClient)
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

        var response = await client.GetAsync($"{_baseUrl}/movies");

        if(!response.IsSuccessStatusCode) return Content("Något gick fel!");

        var json  = await response.Content.ReadAsStringAsync();

        var movies = JsonSerializer.Deserialize<IList<MovieListViewModel>>(json, _options);

        return View("Index", movies);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> MovieById(int id)
    {
        using var client = _httpClient.CreateClient();

        var response = await client.GetAsync($"{_baseUrl}/movies/{id}");

        if(!response.IsSuccessStatusCode) return Content("Något gick fel!");

        var json  = await response.Content.ReadAsStringAsync();

        var movieDetails = JsonSerializer.Deserialize<MovieDetailsViewModel>(json, _options);

        return View("Details", movieDetails);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var movie = new MoviePostViewModel();
        return View("Create", movie);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MoviePostViewModel movie)
    {
       var client = _httpClient.CreateClient();

       var response = await client.PostAsJsonAsync($"{_baseUrl}/movies", movie);

       if(!response.IsSuccessStatusCode) return BadRequest("Felaktig inmatning!");

       return RedirectToAction("Index");
    }
}
