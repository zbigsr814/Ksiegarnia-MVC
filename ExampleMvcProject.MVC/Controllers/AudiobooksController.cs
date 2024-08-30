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
    public class AudiobooksController : BaseController
    {
        private readonly BookstoreDbContext _context;
        IVariablesToController _variables;

        public AudiobooksController(BookstoreDbContext context, IVariablesToController variables) : base(variables)
        {
            _context = context;
            _variables = variables;
        }

        // GET: Audiobooks
        public async Task<IActionResult> Index()
        {
              return _context.audiobooks != null ? 
                          View(await _context.audiobooks.ToListAsync()) :
                          Problem("Entity set 'BookstoreDbContext.audiobooks'  is null.");
        }

        // GET: Audiobooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.audiobooks == null)
            {
                return NotFound();
            }

            var audiobook = await _context.audiobooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audiobook == null)
            {
                return NotFound();
            }

            return View(audiobook);
        }

        // GET: Audiobooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Audiobooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Author,ImagePath,Quantity")] Audiobook audiobook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audiobook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audiobook);
        }

        // GET: Audiobooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.audiobooks == null)
            {
                return NotFound();
            }

            var audiobook = await _context.audiobooks.FindAsync(id);
            if (audiobook == null)
            {
                return NotFound();
            }
            return View(audiobook);
        }

        // POST: Audiobooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,ImagePath,Quantity")] Audiobook audiobook)
        {
            if (id != audiobook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audiobook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudiobookExists(audiobook.Id))
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
            return View(audiobook);
        }

        // GET: Audiobooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.audiobooks == null)
            {
                return NotFound();
            }

            var audiobook = await _context.audiobooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audiobook == null)
            {
                return NotFound();
            }

            return View(audiobook);
        }

        // POST: Audiobooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.audiobooks == null)
            {
                return Problem("Entity set 'BookstoreDbContext.audiobooks'  is null.");
            }
            var audiobook = await _context.audiobooks.FindAsync(id);
            if (audiobook != null)
            {
                _context.audiobooks.Remove(audiobook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudiobookExists(int id)
        {
          return (_context.audiobooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
