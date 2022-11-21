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
    public class TipoEventosController : Controller
    {
        private readonly WebApplication_BilheteiraContext _context;

        public TipoEventosController(WebApplication_BilheteiraContext context)
        {
            _context = context;
        }

        // GET: TipoEventos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEvento.ToListAsync());
        }

        // GET: TipoEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // GET: TipoEventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEvento);
        }

        // GET: TipoEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }
            return View(tipoEvento);
        }

        // POST: TipoEventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] TipoEvento tipoEvento)
        {
            if (id != tipoEvento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEventoExists(tipoEvento.Id))
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
            return View(tipoEvento);
        }

        // GET: TipoEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // POST: TipoEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            _context.TipoEvento.Remove(tipoEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEventoExists(int id)
        {
            return _context.TipoEvento.Any(e => e.Id == id);
        }
    }
}
