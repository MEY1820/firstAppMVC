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

    public class AutorFiguraController : Controller
    {
        private readonly ejemplocontext _context;

        public AutorFiguraController(ejemplocontext context)
        {
            _context = context;
        }

        // GET: AutorFigura
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutorFigura.ToListAsync());
        }

        // GET: AutorFigura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorFigura = await _context.AutorFigura
                .FirstOrDefaultAsync(m => m.AutorFiguraID == id);
            if (autorFigura == null)
            {
                return NotFound();
            }

            return View(autorFigura);
        }

        // GET: AutorFigura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutorFigura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutorFiguraID,Nombre,Apellido,Correo,Genero,Direccion")] AutorFigura autorFigura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorFigura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorFigura);
        }

        // GET: AutorFigura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorFigura = await _context.AutorFigura.FindAsync(id);
            if (autorFigura == null)
            {
                return NotFound();
            }
            return View(autorFigura);
        }

        // POST: AutorFigura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutorFiguraID,Nombre,Apellido,Correo,Genero,Direccion")] AutorFigura autorFigura)
        {
            if (id != autorFigura.AutorFiguraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorFigura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorFiguraExists(autorFigura.AutorFiguraID))
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
            return View(autorFigura);
        }

        // GET: AutorFigura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorFigura = await _context.AutorFigura
                .FirstOrDefaultAsync(m => m.AutorFiguraID == id);
            if (autorFigura == null)
            {
                return NotFound();
            }

            return View(autorFigura);
        }

        // POST: AutorFigura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorFigura = await _context.AutorFigura.FindAsync(id);
            _context.AutorFigura.Remove(autorFigura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorFiguraExists(int id)
        {
            return _context.AutorFigura.Any(e => e.AutorFiguraID == id);
        }
    }
}
