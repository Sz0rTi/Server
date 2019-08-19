using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAO.Context;
using DAO.Models;
using Managment.Models.Out;
using Managment.Models.In;
using Managment.Services;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryOut>>> GetCategories()
        {
            return await _service.GetCategories();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryOut>> GetCategory(Guid id)
        {
            return await _service.GetCategory(id);
        }

        // PUT: api/Categories/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, Category category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryOut>> PostCategory(CategoryIn category)
        {
            return await _service.PostCategory(category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryOut>> DeleteCategory(Guid id)
        {
            return await _service.DeleteCategory(id);
        }

    }
}
