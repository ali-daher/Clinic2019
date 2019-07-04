using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.Data;
using Clinic.Models;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reminder_adminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Reminder_adminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reminder_admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reminder_admin>>> GetReminder_Admins()
        {
            return await _context.Reminder_Admins.ToListAsync();
        }

        // GET: api/Reminder_admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reminder_admin>> GetReminder_admin(int id)
        {
            var reminder_admin = await _context.Reminder_Admins.FindAsync(id);

            if (reminder_admin == null)
            {
                return NotFound();
            }

            return reminder_admin;
        }

        // PUT: api/Reminder_admin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminder_admin(int id, Reminder_admin reminder_admin)
        {
            if (id != reminder_admin.reminder_id)
            {
                return BadRequest();
            }

            _context.Entry(reminder_admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Reminder_adminExists(id))
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

        // POST: api/Reminder_admin
        [HttpPost]
        public async Task<ActionResult<Reminder_admin>> PostReminder_admin(Reminder_admin reminder_admin)
        {
            _context.Reminder_Admins.Add(reminder_admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReminder_admin", new { id = reminder_admin.reminder_id }, reminder_admin);
        }

        // DELETE: api/Reminder_admin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reminder_admin>> DeleteReminder_admin(int id)
        {
            var reminder_admin = await _context.Reminder_Admins.FindAsync(id);
            if (reminder_admin == null)
            {
                return NotFound();
            }

            _context.Reminder_Admins.Remove(reminder_admin);
            await _context.SaveChangesAsync();

            return reminder_admin;
        }

        private bool Reminder_adminExists(int id)
        {
            return _context.Reminder_Admins.Any(e => e.reminder_id == id);
        }
    }
}
