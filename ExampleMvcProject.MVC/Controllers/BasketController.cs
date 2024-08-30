using Azure.Core;
using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Models;
using ExampleMvcProject.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ExampleMvcProject.MVC.Interfaces;
using NuGet.Packaging;

namespace ExampleMvcProject.MVC.Controllers
{
    [Controller]
    public class BasketController : BaseController
    {
        private BookstoreDbContext _dbContext;
        private readonly ILogger<BasketController> _logger;
        IVariablesToController _variables;

        public BasketController(ILogger<BasketController> logger, BookstoreDbContext dbContext, IVariablesToController variables) : base(variables)
        {
            _logger = logger;
            _dbContext = dbContext;
            _variables = variables;
        }

        [HttpGet]
        public IActionResult AddElementToBasket([FromQuery] int ElementId, [FromQuery] string MediaType)
        {


            Basket newBasketElement = new Basket()
            {
                MediaType = MediaType,
                Count = 1,
                MediaId = ElementId
            };

            _dbContext.baskets.Add(newBasketElement);
            _dbContext.SaveChanges();

            var referrer = Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }

        public IActionResult Show()
        {
            List<int> booksId = _dbContext.baskets
                .Where(b => b.MediaType == "Book")
                .Select(b => b.MediaId)
                .ToList();

            List<int> audiobooksId = _dbContext.baskets
                .Where(b => b.MediaType == "Audiobook")
                .Select(b => b.MediaId)
                .ToList();

            List<int> musicId = _dbContext.baskets
                .Where(b => b.MediaType == "Music")
                .Select(b => b.MediaId)
                .ToList();

            List<int> filmsId = _dbContext.baskets
                .Where(b => b.MediaType == "Film")
                .Select(b => b.MediaId)
                .ToList();

            BasketAnyElements basketAnyElements = new BasketAnyElements()
            {
                Books = _dbContext.books
                    .Where(b => booksId.Contains(b.Id))
                    .ToList(),
                Audiobooks = _dbContext.audiobooks
                    .Where(b => audiobooksId.Contains(b.Id))
                    .ToList(),
                Musics = _dbContext.musics
                    .Where(b => musicId.Contains(b.Id))
                    .ToList(),
                Films = _dbContext.films
                    .Where(b => filmsId.Contains(b.Id))
                    .ToList()

            };

            return View(basketAnyElements);
        }

        public IActionResult CleanBasket()
        {
            var allBasketItem = _dbContext.baskets.ToList();
            _dbContext.baskets.RemoveRange(allBasketItem);
            _dbContext.SaveChanges();

            var referer = Request.Headers["Referer"];
            return Redirect(referer);
        }
    }
}
