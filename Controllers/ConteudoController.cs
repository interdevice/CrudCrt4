using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudCrt4.Data;
using CrudCrt4.Models;
using System.IO;

namespace CrudCrt4.Controllers
{
    public class ConteudoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConteudoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conteudo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conteudo.ToListAsync());
        }

        // GET: Conteudo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // GET: Conteudo/Quem/5
        public async Task<IActionResult> Quem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // GET: Conteudo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conteudo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("Id,Menu,Titulo,Artigo,Imagem,Upload")] Conteudo conteudo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteudo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(conteudo);
        }

        // GET: Conteudo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }
            return View(conteudo);
        }

        // POST: Conteudo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Menu,Titulo,Artigo,Imagem,Upload")] Conteudo conteudo)
        {
            if (id != conteudo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteudo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteudoExists(conteudo.Id))
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
            return View(conteudo);
        }

        // GET: Conteudo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteudo = await _context.Conteudo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteudo == null)
            {
                return NotFound();
            }

            return View(conteudo);
        }

        // POST: Conteudo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conteudo = await _context.Conteudo.FindAsync(id);
            _context.Conteudo.Remove(conteudo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteudoExists(int id)
        {
            return _context.Conteudo.Any(e => e.Id == id);
        }
    }
}
