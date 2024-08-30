using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExampleMvcProject.MVC.Models;
using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Interfaces;
using ExampleMvcProject.MVC.Service;

namespace ExampleMvcProject.MVC.Controllers;

public class HomeController : BaseController
{
    private BookstoreDbContext _dbContext;
    private readonly ILogger<HomeController> _logger;
    IVariablesToController _variables;

    public HomeController(ILogger<HomeController> logger, BookstoreDbContext dbContext, IVariablesToController variables) : base(variables)
    {
        _logger = logger;
        _dbContext = dbContext;
        _variables = variables;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Books()
    {
        var books = _dbContext.books.ToList();

        return View(books);
    }

    public IActionResult Audiobooks()
    {
        var audiobooks = _dbContext.audiobooks.ToList();
        return View(audiobooks);
    }

    public IActionResult Musics([FromQuery] string musicType="All", [FromQuery] string sorting="normal")
    {
        TempData["musicType"] = musicType;
        TempData["sorting"] = sorting;

        var musics = _dbContext.musics.ToList();

        // Sortowanie według tytułu w zależności od parametru sorting
        if (sorting == "desc")
        {
            musics = musics.OrderByDescending(m => m.Title).ToList();  // Sortuj malejąco
        }
        else if (sorting == "normal")
        {
            musics = musics.OrderBy(m => m.Title).ToList();  // Sortuj rosnąco (domyślnie)
        }

        // Zwróć wszystkie książki jeżeli tak wybrano
        if (musicType == "All") return View(musics);

        // Pobierz dane na podstawie przekazanego musicType
        musics = musics
            .Where(m => m.MusicType == musicType)
            .ToList();

        return View(musics);
    }

    public IActionResult Films([FromQuery] string filmType = "All", [FromQuery] string sorting = "normal")
    {
        TempData["filmType"] = filmType;
        TempData["sorting"] = sorting;

        var films = _dbContext.films.ToList();

        // Sortowanie według tytułu w zależności od parametru sorting
        if (sorting == "desc")
        {
            films = films.OrderByDescending(m => m.Title).ToList();  // Sortuj malejąco
        }
        else if (sorting == "normal")
        {
            films = films.OrderBy(m => m.Title).ToList();  // Sortuj rosnąco (domyślnie)
        }

        // Zwróć wszystkie książki jeżeli tak wybrano
        if (filmType == "All") return View(films);

        // Pobierz dane na podstawie przekazanego musicType
        films = films
            .Where(m => m.FilmType == filmType)
            .ToList();

        return View(films);
    }

    public IActionResult Search([FromQuery] string searchingText = null)
    {
        var referer = Request.Headers["Referer"].ToString();
        if (searchingText == null) return RedirectToAction(referer);

        BasketAnyElements searchedElements = new BasketAnyElements()
        {
            Books = _dbContext.books
                .Where(b => b.Title.Contains(searchingText))
                .ToList(),
            Audiobooks = _dbContext.audiobooks
                .Where(a => a.Title.Contains(searchingText))
                .ToList(),
            Musics = _dbContext.musics
                .Where(m => m.Title.Contains(searchingText))
                .ToList(),
            Films = _dbContext.films
                .Where(f => f.Title.Contains(searchingText))
                .ToList()
        };

        return View(searchedElements);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
