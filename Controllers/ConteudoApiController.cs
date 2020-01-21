using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using CrudCrt4.Data;
using CrudCrt4.Models;

namespace CrudCrt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("local")]
    public class ConteudoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConteudoApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ConteudoApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conteudo>>> GetConteudo()
        {
            return await _context.Conteudo.ToListAsync();
        }

        // GET: api/ConteudoApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conteudo>> GetConteudo(int id)
        {
            var conteudo = await _context.Conteudo.FindAsync(id);

            if (conteudo == null)
            {
                return NotFound();
            }

            return conteudo;
        }

        // PUT: api/ConteudoApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConteudo(int id, Conteudo conteudo)
        {
            if (id != conteudo.Id)
            {
                return BadRequest();
            }

            _context.Entry(conteudo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConteudoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ConteudoApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Conteudo>> PostConteudo(Conteudo conteudo)
        {
            _context.Conteudo.Add(conteudo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConteudo", new { id = conteudo.Id }, conteudo);
        }

        // DELETE: api/ConteudoApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conteudo>> DeleteConteudo(int id)
        {
            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }

            _context.Conteudo.Remove(conteudo);
            await _context.SaveChangesAsync();

            return conteudo;
        }

        private bool ConteudoExists(int id)
        {
            return _context.Conteudo.Any(e => e.Id == id);
        }
    }
}
