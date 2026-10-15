
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RaceDay.Data;

namespace RaceDay.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly RaceDayContext _db;

        public CategoriesController(RaceDayContext db)
        {
            _db = db;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }

        // GET: api/categories/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _db.Categories.FindAsync(id);

            if (category == null)
                return NotFound(new { message = "Category not found." });

            return Ok(category);
        }

        // POST: api/categories
        [Authorize(Roles = "Organiser")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            category.CategoryID = 0;

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCategory),
                new { id = category.CategoryID },
                category);
        }

        // PUT: api/categories/1
        [Authorize(Roles = "Organiser")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory(
            int id, Category updatedCategory)
        {
            if (id != updatedCategory.CategoryID)
                return BadRequest(new { message = "Category ID does not match." });

            var existingCategory = await _db.Categories.FindAsync(id);

            if (existingCategory == null)
                return NotFound(new { message = "Category not found." });

            existingCategory.CategoryName = updatedCategory.CategoryName;
            existingCategory.Distance = updatedCategory.Distance;
            existingCategory.EventID = updatedCategory.EventID;

            await _db.SaveChangesAsync();

            return Ok(existingCategory);
        }

        // DELETE: api/categories/1
        [Authorize(Roles = "Organiser")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _db.Categories.FindAsync(id);

            if (category == null)
                return NotFound(new { message = "Category not found." });

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
