#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JuhMesquitaViagens.Models;

namespace JuhMesquitaViagens.Controllers
{
    public class DestiniesController : Controller
    {
        private readonly Context _context;

        public DestiniesController(Context context)
        {
            _context = context;
        }

        // GET: Destinies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destiny.ToListAsync());
        }

        // GET: Destinies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destiny = await _context.Destiny
                .FirstOrDefaultAsync(m => m.id == id);
            if (destiny == null)
            {
                return NotFound();
            }

            return View(destiny);
        }

        // GET: Destinies/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Destiny()
        {
            var destinies = _context.Destiny.ToList();
            return View(destinies);
        }

        // POST: Destinies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,country,state,municipality,valueDaily,promotion")] Destiny destiny)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destiny);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destiny);
        }

        // GET: Destinies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destiny = await _context.Destiny.FindAsync(id);
            if (destiny == null)
            {
                return NotFound();
            }
            return View(destiny);
        }

        // POST: Destinies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,country,state,municipality,valueDaily,promotion")] Destiny destiny)
        {
            if (id != destiny.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destiny);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinyExists(destiny.id))
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
            return View(destiny);
        }

        // GET: Destinies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destiny = await _context.Destiny
                .FirstOrDefaultAsync(m => m.id == id);
            if (destiny == null)
            {
                return NotFound();
            }

            return View(destiny);
        }

        // POST: Destinies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destiny = await _context.Destiny.FindAsync(id);
            _context.Destiny.Remove(destiny);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinyExists(int id)
        {
            return _context.Destiny.Any(e => e.id == id);
        }
    }
}
