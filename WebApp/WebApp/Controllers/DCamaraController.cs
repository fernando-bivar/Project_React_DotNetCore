using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("DCamara")]
    [ApiController]
    public class DCamaraController : ControllerBase
    {
        private readonly CamaraDBContext _context;

        public DCamaraController(CamaraDBContext context)
        {
            _context = context;
        }

        // GET: DCamara/Get
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<DCamara>>> GetDCamaras()
        {
            return await _context.DCamaras.ToListAsync();
        }

        // GET: DCamara/GetId/1
        [HttpGet("GetId/{id}")]
        public async Task<ActionResult<DCamara>> GetDCamara(int id)
        {
            var dCamara = await _context.DCamaras.FindAsync(id);

            if (dCamara == null)
            {
                return NotFound();
            }

            return dCamara;
        }

        // PUT: DCamara/Put/1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> PutDCamara(int id, DCamara dCamara)
        {
            dCamara.id = id;

            _context.Entry(dCamara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCamaraExists(id))
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

        // POST: DCamara/Post
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("Post")]
        public async Task<ActionResult<DCamara>> PostDCamara(DCamara dCamara)
        {
            _context.DCamaras.Add(dCamara);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCamara", new { id = dCamara.id }, dCamara);
        }

        // DELETE: DCamara/Del/1
        [HttpDelete("Del/{id}")]
        public async Task<ActionResult<DCamara>> DeleteDCamara(int id)
        {
            var dCamara = await _context.DCamaras.FindAsync(id);
            if (dCamara == null)
            {
                return NotFound();
            }

            _context.DCamaras.Remove(dCamara);
            await _context.SaveChangesAsync();

            return dCamara;
        }

        private bool DCamaraExists(int id)
        {
            return _context.DCamaras.Any(e => e.id == id);
        }
    }
}
