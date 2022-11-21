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
    public class SubTipoEventosController : Controller
    {
        private readonly WebApplication_BilheteiraContext _context;

        public SubTipoEventosController(WebApplication_BilheteiraContext context)
        {
            _context = context;
        }

        // GET: SubTipoEventos
        public async Task<IActionResult> Index()
        {
            var webApplication_BilheteiraContext = _context.SubTipoEvento.Include(s => s.TipoEvento);
            return View(await webApplication_BilheteiraContext.ToListAsync());
        }

        // GET: SubTipoEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTipoEvento = await _context.SubTipoEvento
                .Include(s => s.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTipoEvento == null)
            {
                return NotFound();
            }

            return View(subTipoEvento);
        }

        // GET: SubTipoEventos/Create
        public IActionResult Create()
        {
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id");
            return View();
        }

        // POST: SubTipoEventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,TipoEventoId")] SubTipoEvento subTipoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subTipoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id", subTipoEvento.TipoEventoId);
            return View(subTipoEvento);
        }

        // GET: SubTipoEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTipoEvento = await _context.SubTipoEvento.FindAsync(id);
            if (subTipoEvento == null)
            {
                return NotFound();
            }
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id", subTipoEvento.TipoEventoId);
            return View(subTipoEvento);
        }

        // POST: SubTipoEventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,TipoEventoId")] SubTipoEvento subTipoEvento)
        {
            if (id != subTipoEvento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subTipoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubTipoEventoExists(subTipoEvento.Id))
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
            ViewData["TipoEventoId"] = new SelectList(_context.TipoEvento, "Id", "Id", subTipoEvento.TipoEventoId);
            return View(subTipoEvento);
        }

        // GET: SubTipoEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTipoEvento = await _context.SubTipoEvento
                .Include(s => s.TipoEvento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTipoEvento == null)
            {
                return NotFound();
            }

            return View(subTipoEvento);
        }

        // POST: SubTipoEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subTipoEvento = await _context.SubTipoEvento.FindAsync(id);
            _context.SubTipoEvento.Remove(subTipoEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubTipoEventoExists(int id)
        {
            return _context.SubTipoEvento.Any(e => e.Id == id);
        }
    }
}
