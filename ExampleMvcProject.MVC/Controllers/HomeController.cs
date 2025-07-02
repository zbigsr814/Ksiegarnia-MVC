using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExampleMvcProject.MVC.Models;
using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Interfaces;
using ExampleMvcProject.MVC.Service;
using SecondWebApp.Interfaces;
using System.Net.Mail;

namespace ExampleMvcProject.MVC.Controllers;

public class HomeController : BaseController
{
    private readonly IEmailSender emailSender;
    private BookstoreDbContext _dbContext;
    private readonly ILogger<HomeController> _logger;
    IVariablesToController _variables;

    public HomeController(ILogger<HomeController> logger, BookstoreDbContext dbContext, IVariablesToController variables, IEmailSender emailSender) 
        : base(variables)
    {
        _logger = logger;
        _dbContext = dbContext;
        _variables = variables;
        this.emailSender = emailSender;

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

    public IActionResult Ebooks([FromQuery] string ebookType = "All", [FromQuery] string sorting = "normal")
    {
        TempData["ebookType"] = ebookType;
        TempData["sorting"] = sorting;

        var ebooks = _dbContext.ebooks.ToList();

        // Sortowanie według tytułu w zależności od parametru sorting
        if (sorting == "desc")
        {
            ebooks = ebooks.OrderByDescending(m => m.Title).ToList();  // Sortuj malejąco
        }
        else if (sorting == "normal")
        {
            ebooks = ebooks.OrderBy(m => m.Title).ToList();  // Sortuj rosnąco (domyślnie)
        }

        // Zwróć wszystkie książki jeżeli tak wybrano
        if (ebookType == "All") return View(ebooks);

        //Pobierz dane na podstawie przekazanego musicType
        ebooks = ebooks
            .Where(m => m.EbookType == ebookType)
            .ToList();

        return View(ebooks);
    }

    public IActionResult Games([FromQuery] string gameType = "All", [FromQuery] string sorting = "normal")
    {
        TempData["gameType"] = gameType;
        TempData["sorting"] = sorting;

        var games = _dbContext.games.ToList();

        // Sortowanie według tytułu w zależności od parametru sorting
        if (sorting == "desc")
        {
            games = games.OrderByDescending(m => m.Title).ToList();  // Sortuj malejąco
        }
        else if (sorting == "normal")
        {
            games = games.OrderBy(m => m.Title).ToList();  // Sortuj rosnąco (domyślnie)
        }

        // Zwróć wszystkie gry jeżeli tak wybrano
        if (gameType == "All") return View(games);

        // Pobierz dane na podstawie przekazanego musicType
        games = games
            .Where(m => m.GameType == gameType)
            .ToList();

        return View(games);
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

    public IActionResult Contact()
    {
        EmailModel emailModel = new EmailModel();
        emailModel.Receiver = "zbigniew.sr@interia.pl";
        emailModel.Subject = "Spotkanie rekrutacyjne";
        emailModel.Text = "Z przyjemnością informujemy że firma XYZ pozytywnie rozpatrzyła Pana CV oraz aplikację. Zostaje Pan zaproszony na rozmowę rekrutacyjną," +
                            " która odbędzie się dnia ABC o godzinie DEF, w miejscu GHI.";
        return View(emailModel);
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(EmailModel emailModel)
    {
        string referer = Request.Headers["Referer"].ToString();

        try
        {
            var validEmail = new MailAddress(emailModel.Receiver);
        }
        catch (FormatException ex)
        {
            TempData["Message"] = "Email nieprawidłowy!";
            TempData["MessageType"] = "Warning";
            return Redirect(referer);
        }

        await emailSender.SendEmailAsync(emailModel.Receiver, emailModel.Subject, emailModel.Text);

        if (!string.IsNullOrEmpty(referer))
        {
            TempData["Message"] = "Email został wysłany!";
            TempData["MessageType"] = "Successful";
            return Redirect(referer);
        }

        // fallback jeśli referer jest pusty
        return RedirectToAction("Index", "Home");
        return View();
    }

    public IActionResult Bookstores()
    {
        var bookstores = _dbContext.bookstories.ToList();

        return View(bookstores);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
