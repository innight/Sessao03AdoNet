using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bilheteira;
using WebApplication_Bilheteira.Data;

namespace WebApplication_AspNetCoreMVC_Bilheteira.Controllers
{
    public class SectoresController : Controller
    {
        private readonly WebApplication_BilheteiraContext _context;

        public SectoresController(WebApplication_BilheteiraContext context)
        {
            _context = context;
        }

        // GET: Sectores
        public async Task<IActionResult> Index()
        {
            var webApplication_BilheteiraContext = _context.Sector.Include(s => s.Sessao);
            return View(await webApplication_BilheteiraContext.ToListAsync());
        }

        // GET: Sectores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .Include(s => s.Sessao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // GET: Sectores/Create
        public IActionResult Create()
        {
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "Id", "Id");
            return View();
        }

        // POST: Sectores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,QuantidadeLugares,Estado,Preco,SessaoId")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "Id", "Id", sector.SessaoId);
            return View(sector);
        }

        // GET: Sectores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "Id", "Id", sector.SessaoId);
            return View(sector);
        }

        // POST: Sectores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,QuantidadeLugares,Estado,Preco,SessaoId")] Sector sector)
        {
            if (id != sector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.Id))
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
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "Id", "Id", sector.SessaoId);
            return View(sector);
        }

        // GET: Sectores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .Include(s => s.Sessao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Sectores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sector = await _context.Sector.FindAsync(id);
            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorExists(int id)
        {
            return _context.Sector.Any(e => e.Id == id);
        }
    }
}
