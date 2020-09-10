using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FCA_Login_WebApi.Models;
using System.Net.Http;

namespace FCA_Login_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly MainContext _context;

        public AuthUserController(MainContext context)
        {
            _context = context;
        }

        // GET: api/AuthUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthUser>>> GetAuthUser()
        {
            string url="https://jsonplaceholder.typicode.com/todos"; // sample url
            using (HttpClient client = new HttpClient())
            {
                var test = await client.GetStringAsync(url);
            }

            return await _context.AuthUser.ToListAsync();
        }

        // GET: api/AuthUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthUser>> GetAuthUser(int id)
        {
            var authUser = await _context.AuthUser.FindAsync(id);

            if (authUser == null)
            {
                return NotFound();
            }

            return authUser;
        }

        // PUT: api/AuthUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthUser(int id, AuthUser authUser)
        {
            if (id != authUser.id)
            {
                return BadRequest();
            }

            _context.Entry(authUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthUserExists(id))
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

        // POST: api/AuthUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuthUser>> PostAuthUser(AuthUser authUser)
        {
            _context.AuthUser.Add(authUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthUser", new { id = authUser.id }, authUser);
        }

        // DELETE: api/AuthUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthUser>> DeleteAuthUser(int id)
        {
            var authUser = await _context.AuthUser.FindAsync(id);
            if (authUser == null)
            {
                return NotFound();
            }

            _context.AuthUser.Remove(authUser);
            await _context.SaveChangesAsync();

            return authUser;
        }

        private bool AuthUserExists(int id)
        {
            return _context.AuthUser.Any(e => e.id == id);
        }
    }
}
