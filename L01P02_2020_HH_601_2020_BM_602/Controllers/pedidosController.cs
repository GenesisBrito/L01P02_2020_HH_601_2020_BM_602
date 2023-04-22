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
    public class pedidosController : Controller
    {
        private readonly equiposDbContext _context;

        public pedidosController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: pedidos
        public async Task<IActionResult> Index()
        {
            return _context.pedidos != null ?
                        View(await _context.pedidos.ToListAsync()) :
                        Problem("Entity set 'equiposDbContext.Pedidos'  is null.");
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pedidos == null)
            {
                return NotFound();
            }

            var Pedidos = await _context.pedidos
                .FirstOrDefaultAsync(m => m.pedido_id == id);
            if (Pedidos == null)
            {
                return NotFound();
            }

            return View(Pedidos);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pedido_id,nombre_Pedido")] pedidos Pedidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Pedidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Pedidos);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pedidos == null)
            {
                return NotFound();
            }

            var Pedidos = await _context.pedidos.FindAsync(id);
            if (Pedidos == null)
            {
                return NotFound();
            }
            return View(Pedidos);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pedido_id,nombre_Pedido")] pedidos Pedidos)
        {
            if (id != Pedidos.pedido_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Pedidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosExists(Pedidos.pedido_id))
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
            return View(Pedidos);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pedidos == null)
            {
                return NotFound();
            }

            var Pedidos = await _context.pedidos
                .FirstOrDefaultAsync(m => m.pedido_id == id);
            if (Pedidos == null)
            {
                return NotFound();
            }

            return View(Pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pedidos == null)
            {
                return Problem("Entity set 'equiposDbContext.Pedidos'  is null.");
            }
            var Pedidos = await _context.pedidos.FindAsync(id);
            if (Pedidos != null)
            {
                _context.pedidos.Remove(Pedidos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosExists(int id)
        {
            return (_context.pedidos?.Any(e => e.pedido_id == id)).GetValueOrDefault();
        }

    }
}
