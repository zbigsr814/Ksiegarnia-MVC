using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Service;
using ExampleMvcProject.MVC.Interfaces;

namespace ExampleMvcProject.MVC.Controllers
{
    public class MusicsController : BaseController
    {
        private readonly BookstoreDbContext _context;
        private IVariablesToController _variables;

        public MusicsController(BookstoreDbContext context, IVariablesToController variables) : base(variables)
        {
            _context = context;
            _variables = variables;
        }

        // GET: Musics
        public async Task<IActionResult> Index()
        {
              return _context.musics != null ? 
                          View(await _context.musics.ToListAsync()) :
                          Problem("Entity set 'BookstoreDbContext.musics'  is null.");
        }

        // GET: Musics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.musics == null)
            {
                return NotFound();
            }

            var music = await _context.musics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // GET: Musics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,MusicType,ImagePath,Quantity")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Musics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.musics == null)
            {
                return NotFound();
            }

            var music = await _context.musics.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: Musics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,MusicType,ImagePath,Quantity")] Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.Id))
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
            return View(music);
        }

        // GET: Musics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.musics == null)
            {
                return NotFound();
            }

            var music = await _context.musics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // POST: Musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.musics == null)
            {
                return Problem("Entity set 'BookstoreDbContext.musics'  is null.");
            }
            var music = await _context.musics.FindAsync(id);
            if (music != null)
            {
                _context.musics.Remove(music);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicExists(int id)
        {
          return (_context.musics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
