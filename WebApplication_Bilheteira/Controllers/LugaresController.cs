using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bilheteira;
using WebApplication_Bilheteira.Data;

namespace WebApplication_Bilheteira.Controllers
{
    public class LugaresController : Controller
    {
        private readonly WebApplication_BilheteiraContext _context;

        public LugaresController(WebApplication_BilheteiraContext context)
        {
            _context = context;
        }

        // GET: Lugares
        public async Task<IActionResult> Index()
        {
            var webApplication_BilheteiraContext = _context.Lugar.Include(l => l.Sector);
            return View(await webApplication_BilheteiraContext.ToListAsync());
        }

        // GET: Lugares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugar
                .Include(l => l.Sector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lugar == null)
            {
                return NotFound();
            }

            return View(lugar);
        }

        // GET: Lugares/Create
        public IActionResult Create()
        {
            ViewData["SectorId"] = new SelectList(_context.Set<Sector>(), "Id", "Id");
            return View();
        }

        // POST: Lugares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fila,Numero,Estado,SectorId")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lugar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SectorId"] = new SelectList(_context.Set<Sector>(), "Id", "Id", lugar.SectorId);
            return View(lugar);
        }

        // GET: Lugares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugar.FindAsync(id);
            if (lugar == null)
            {
                return NotFound();
            }
            ViewData["SectorId"] = new SelectList(_context.Set<Sector>(), "Id", "Id", lugar.SectorId);
            return View(lugar);
        }

        // POST: Lugares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fila,Numero,Estado,SectorId")] Lugar lugar)
        {
            if (id != lugar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lugar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LugarExists(lugar.Id))
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
            ViewData["SectorId"] = new SelectList(_context.Set<Sector>(), "Id", "Id", lugar.SectorId);
            return View(lugar);
        }

        // GET: Lugares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lugar = await _context.Lugar
                .Include(l => l.Sector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lugar == null)
            {
                return NotFound();
            }

            return View(lugar);
        }

        // POST: Lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lugar = await _context.Lugar.FindAsync(id);
            _context.Lugar.Remove(lugar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LugarExists(int id)
        {
            return _context.Lugar.Any(e => e.Id == id);
        }
    }
}
