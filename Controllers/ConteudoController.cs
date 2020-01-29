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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using CrudCrt4.Views.ViewModels;

namespace CrudCrt4.Controllers
{
    public class ConteudoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _env;

        public ConteudoController(
            ApplicationDbContext context,
            SignInManager<IdentityUser> signInManager,
            IWebHostEnvironment env)
        {
            _context = context;
            _signInManager = signInManager;
            _env = env;
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
            return View(new CreateConteudoViewModel());
        }

        // POST: Conteudo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(CreateConteudoViewModel conteudo)
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    IFormFile file = null;
                    if (Request.Form.Files.Count > 0)
                    {
                        file = Request.Form.Files[0];
                        var uniqueFileName = GetUniqueFileName(file.FileName);
                        var uploads = Path.Combine(_env.WebRootPath, "Upload/imagens");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));
                        conteudo.Upload = uniqueFileName;
                    }
                    else
                    {
                        ModelState.AddModelError("Upload", "Por favor, anexe um arquivo.");
                        return View(conteudo);
                    }

                    var model = new Conteudo(
                        conteudo.Menu,
                        conteudo.Titulo,
                        conteudo.Artigo,
                        conteudo.Imagem,
                        conteudo.Upload);

                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(conteudo);
            }

            return RedirectToAction(nameof(Index));
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

            var model = new EditConteudoViewModel(
                conteudo.Id,
                conteudo.Menu,
                conteudo.Titulo,
                conteudo.Artigo,
                conteudo.Imagem,
                conteudo.Upload);

            //var uploads = Path.Combine(_env.WebRootPath, "Upload");
            //model.FullUploadPath = Path.Combine(uploads, model.Upload);

            return View(model);
        }

        // POST: Conteudo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditConteudoViewModel conteudo)
        {
            if (id != conteudo.Id)
            {
                return NotFound();
            }

            if (_signInManager.IsSignedIn(User))
            {
                if (ModelState.IsValid)
                {
                    IFormFile file = null;
                    if (Request.Form.Files.Count > 0)
                    {
                        file = Request.Form.Files[0];
                        var uniqueFileName = GetUniqueFileName(file.FileName);
                        var uploads = Path.Combine(_env.WebRootPath, "Upload");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));
                        conteudo.Upload = uniqueFileName;
                    }
                    else
                    {
                        ModelState.AddModelError("Upload", "Por favor, anexe um arquivo.");
                        return View(conteudo);
                    }
                    try
                    {
                        var model = new Conteudo(
                            conteudo.Menu,
                            conteudo.Titulo,
                            conteudo.Artigo,
                            conteudo.Imagem,
                            conteudo.Upload);
                        _context.Update(model);
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
            return RedirectToAction(nameof(Index));
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

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
