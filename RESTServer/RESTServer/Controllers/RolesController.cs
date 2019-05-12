using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTServer.Data;
using RESTServer.Models;
using RESTServer.Resources;

namespace RESTServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public RolesController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<IEnumerable<RoleResource>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);
            return resources;
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResource>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            var response = _mapper.Map<RoleResource>(role);
            if (role == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.ID)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<RoleResource>> PostRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetRole", new { id = role.ID }, role);
            var response = _mapper.Map<RoleResource>(role);
            return response;
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return role;
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.ID == id);
        }
    }
}
