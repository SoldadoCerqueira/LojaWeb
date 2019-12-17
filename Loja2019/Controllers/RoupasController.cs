using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loja2019.Data;
using Loja2019.Models;

namespace Loja2019.Controllers
{
    public class RoupasController : Controller
    {
        private readonly Loja2019Context _context;

        public RoupasController(Loja2019Context context)
        {
            _context = context;
        }

        // GET: Roupas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roupa.ToListAsync());
        }
        public async Task<IActionResult> LancarPedido([Bind("RoupaId,Nome,Quantidade")] Roupa roupa)
        {
            Confeccao confeccao = new Confeccao(roupa);
            _context.Add(roupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(await _context.Roupa.ToListAsync());
        }

        // GET: Roupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = await _context.Roupa
                .FirstOrDefaultAsync(m => m.RoupaId == id);
            if (roupa == null)
            {
                return NotFound();
            }

            return View(roupa);
        }

        // GET: Roupas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roupas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoupaId,Nome,Quantidade")] Roupa roupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roupa);
        }

        // GET: Roupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = await _context.Roupa.FindAsync(id);
            if (roupa == null)
            {
                return NotFound();
            }
            return View(roupa);
        }

        // POST: Roupas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoupaId,Nome,Quantidade")] Roupa roupa)
        {
            if (id != roupa.RoupaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoupaExists(roupa.RoupaId))
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
            if (roupa.Quantidade == 0){
                return RedirectToAction("LancarPedido",roupa);
            }

            
                return View(roupa);
        }

        // GET: Roupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = await _context.Roupa
                .FirstOrDefaultAsync(m => m.RoupaId == id);
            if (roupa == null)
            {
                return NotFound();
            }

            return View(roupa);
        }

        // POST: Roupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roupa = await _context.Roupa.FindAsync(id);
            _context.Roupa.Remove(roupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoupaExists(int id)
        {
            return _context.Roupa.Any(e => e.RoupaId == id);
        }
    }
}
