using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;
using Microsoft.AspNetCore.Identity;

namespace BDELog.BIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIUserRolesController : ControllerBase
    {
        private readonly BD_Context _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BIUserRolesController(BD_Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/BIUserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<qryUserInRole>>> GetBUserroles()
        {

            var users = _userManager.Users.Select(c => new qryUserInRole()
            {
                UserId = c.Id,
                UserName = c.UserName,
                RoleName = string.Join(", ", _userManager.GetRolesAsync(c).Result.ToArray())
            }).ToList();


            return (users);
        }

        // GET: api/BIUserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BUserrole>> GetBUserrole(int id)
        {
            var bUserrole = await _context.BUserroles.FindAsync(id);

            if (bUserrole == null)
            {
                return NotFound();
            }

            return bUserrole;
        }

        // PUT: api/BIUserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBUserrole(int id, BUserrole bUserrole)
        {
            if (id != bUserrole.Userid)
            {
                return BadRequest();
            }

            _context.Entry(bUserrole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BUserroleExists(id))
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

        // POST: api/BIUserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BUserrole>> PostBUserrole(BUserrole bUserrole)
        {
            _context.BUserroles.Add(bUserrole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BUserroleExists(bUserrole.Userid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBUserrole", new { id = bUserrole.Userid }, bUserrole);
        }

        // DELETE: api/BIUserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBUserrole(int id)
        {
            var bUserrole = await _context.BUserroles.FindAsync(id);
            if (bUserrole == null)
            {
                return NotFound();
            }

            _context.BUserroles.Remove(bUserrole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BUserroleExists(int id)
        {
            return _context.BUserroles.Any(e => e.Userid == id);
        }
    }
}
