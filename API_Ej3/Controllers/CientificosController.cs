﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Ej3.Models;

namespace API_Ej3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CientificosController : ControllerBase
    {
        private readonly APIContext _context;

        public CientificosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cientificos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientificos>>> GetCientificos()
        {
            return await _context.Cientificos.ToListAsync();
        }

        // GET: api/Cientificos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientificos>> GetCientificos(int id)
        {
            var cientificos = await _context.Cientificos.FindAsync(id);

            if (cientificos == null)
            {
                return NotFound();
            }

            return cientificos;
        }

        // PUT: api/Cientificos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientificos(int id, Cientificos cientificos)
        {
            if (id != cientificos.DNI)
            {
                return BadRequest();
            }

            _context.Entry(cientificos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CientificosExists(id))
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

        // POST: api/Cientificos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cientificos>> PostCientificos(Cientificos cientificos)
        {
            _context.Cientificos.Add(cientificos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCientificos", new { id = cientificos.DNI }, cientificos);
        }

        // DELETE: api/Cientificos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cientificos>> DeleteCientificos(int id)
        {
            var cientificos = await _context.Cientificos.FindAsync(id);
            if (cientificos == null)
            {
                return NotFound();
            }

            _context.Cientificos.Remove(cientificos);
            await _context.SaveChangesAsync();

            return cientificos;
        }

        private bool CientificosExists(int id)
        {
            return _context.Cientificos.Any(e => e.DNI == id);
        }
    }
}
