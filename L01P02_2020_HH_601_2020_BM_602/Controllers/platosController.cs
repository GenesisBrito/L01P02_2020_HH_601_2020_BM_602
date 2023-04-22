using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020_HH_601_2020_BM_602.Models;

namespace L01P02_2020_HH_601_2020_BM_602.Controllers
{
    public class platosController : Controller
    {
        private readonly equiposDbContext _context;

        public platosController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: platos
        public async Task<IActionResult> Index()
        {
            return _context.platos != null ?
                        View(await _context.platos.ToListAsync()) :
                        Problem("Entity set 'equiposDbContext.platos'  is null.");
        }

        // GET: platos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.platos == null)
            {
                return NotFound();
            }

            var platos = await _context.platos
                .FirstOrDefaultAsync(m => m.plato_id == id);
            if (platos == null)
            {
                return NotFound();
            }

            return View(platos);
        }

        // GET: platos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: platos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("plato_id,nombre_plato")] platos platos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platos);
        }

        // GET: platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.platos == null)
            {
                return NotFound();
            }

            var platos = await _context.platos.FindAsync(id);
            if (platos == null)
            {
                return NotFound();
            }
            return View(platos);
        }

        // POST: platos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("plato_id,nombre_plato")] platos platos)
        {
            if (id != platos.plato_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!platosExists(platos.plato_id))
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
            return View(platos);
        }

        // GET: platos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.platos == null)
            {
                return NotFound();
            }

            var platos = await _context.platos
                .FirstOrDefaultAsync(m => m.plato_id == id);
            if (platos == null)
            {
                return NotFound();
            }

            return View(platos);
        }

        // POST: platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.platos == null)
            {
                return Problem("Entity set 'equiposDbContext.platos'  is null.");
            }
            var platos = await _context.platos.FindAsync(id);
            if (platos != null)
            {
                _context.platos.Remove(platos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool platosExists(int id)
        {
            return (_context.platos?.Any(e => e.plato_id == id)).GetValueOrDefault();
        }
    }
}
