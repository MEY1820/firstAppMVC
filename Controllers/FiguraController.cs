using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using firstApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace firstApp.Controllers
{
    [Authorize]
    
    public class FiguraController : Controller
    {
        private readonly ejemplocontext _context;

        public FiguraController(ejemplocontext context)
        {
            _context = context;
        }

        // GET: Figura
        public async Task<IActionResult> Index()
        {
            var ejemplocontext = _context.Figura.Include(f => f.AutorFiguras);
            return View(await ejemplocontext.ToListAsync());
        }

        // GET: Figura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figura = await _context.Figura
                .Include(f => f.AutorFiguras)
                .FirstOrDefaultAsync(m => m.figuraId == id);
            if (figura == null)
            {
                return NotFound();
            }

            return View(figura);
        }

        // GET: Figura/Create
        public IActionResult Create()
        {
            ViewData["AutorFiguraID"] = new SelectList(_context.Set<AutorFigura>(), "AutorFiguraID", "Apellido");
            return View();
        }

        // POST: Figura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("figuraId,nombre,lados,angulo,AutorFiguraID")] Figura figura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(figura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorFiguraID"] = new SelectList(_context.Set<AutorFigura>(), "AutorFiguraID", "Apellido", figura.AutorFiguraID);
            return View(figura);
        }

        // GET: Figura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figura = await _context.Figura.FindAsync(id);
            if (figura == null)
            {
                return NotFound();
            }
            ViewData["AutorFiguraID"] = new SelectList(_context.Set<AutorFigura>(), "AutorFiguraID", "Apellido", figura.AutorFiguraID);
            return View(figura);
        }

        // POST: Figura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("figuraId,nombre,lados,angulo,AutorFiguraID")] Figura figura)
        {
            if (id != figura.figuraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(figura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiguraExists(figura.figuraId))
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
            ViewData["AutorFiguraID"] = new SelectList(_context.Set<AutorFigura>(), "AutorFiguraID", "Apellido", figura.AutorFiguraID);
            return View(figura);
        }

        // GET: Figura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figura = await _context.Figura
                .Include(f => f.AutorFiguras)
                .FirstOrDefaultAsync(m => m.figuraId == id);
            if (figura == null)
            {
                return NotFound();
            }

            return View(figura);
        }

        // POST: Figura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var figura = await _context.Figura.FindAsync(id);
            _context.Figura.Remove(figura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiguraExists(int id)
        {
            return _context.Figura.Any(e => e.figuraId == id);
        }
    }
}
