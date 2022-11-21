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
    public class SessoesController : Controller
    {
        private readonly WebApplication_BilheteiraContext _context;

        public SessoesController(WebApplication_BilheteiraContext context)
        {
            _context = context;
        }

        // GET: Sessoes
        public async Task<IActionResult> Index()
        {
            var webApplication_BilheteiraContext = _context.Sessao.Include(s => s.Evento).Include(s => s.Local);
            return View(await webApplication_BilheteiraContext.ToListAsync());
        }

        // GET: Sessoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao
                .Include(s => s.Evento)
                .Include(s => s.Local)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // GET: Sessoes/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Evento, "Id", "Id");
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id");
            return View();
        }

        // POST: Sessoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Detalhe,DataInicio,DataFim,HoraInicio,Estado,EventoId,LocalId")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Evento, "Id", "Id", sessao.EventoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id", sessao.LocalId);
            return View(sessao);
        }

        // GET: Sessoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao.FindAsync(id);
            if (sessao == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Evento, "Id", "Id", sessao.EventoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id", sessao.LocalId);
            return View(sessao);
        }

        // POST: Sessoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Detalhe,DataInicio,DataFim,HoraInicio,Estado,EventoId,LocalId")] Sessao sessao)
        {
            if (id != sessao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessaoExists(sessao.Id))
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
            ViewData["EventoId"] = new SelectList(_context.Evento, "Id", "Id", sessao.EventoId);
            ViewData["LocalId"] = new SelectList(_context.Local, "Id", "Id", sessao.LocalId);
            return View(sessao);
        }

        // GET: Sessoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao
                .Include(s => s.Evento)
                .Include(s => s.Local)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // POST: Sessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessao = await _context.Sessao.FindAsync(id);
            _context.Sessao.Remove(sessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessao.Any(e => e.Id == id);
        }
    }
}
