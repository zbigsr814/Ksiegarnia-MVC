using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Interfaces;
using ExampleMvcProject.MVC.Service;

namespace ExampleMvcProject.MVC.Controllers
{
    public class FilmsController : BaseController
    {
        private readonly BookstoreDbContext _context;
        private IVariablesToController _variables;

        public FilmsController(BookstoreDbContext context, IVariablesToController variables) : base(variables)
        {
            _context = context;
            _variables = variables;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
              return _context.films != null ? 
                          View(await _context.films.ToListAsync()) :
                          Problem("Entity set 'BookstoreDbContext.films'  is null.");
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.films == null)
            {
                return NotFound();
            }

            var film = await _context.films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Director,FilmType,ImagePath,Quantity")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.films == null)
            {
                return NotFound();
            }

            var film = await _context.films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Director,FilmType,ImagePath,Quantity")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.films == null)
            {
                return NotFound();
            }

            var film = await _context.films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.films == null)
            {
                return Problem("Entity set 'BookstoreDbContext.films'  is null.");
            }
            var film = await _context.films.FindAsync(id);
            if (film != null)
            {
                _context.films.Remove(film);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
          return (_context.films?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
