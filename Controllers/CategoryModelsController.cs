using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Models;
using Microsoft.Extensions.Logging;

namespace BookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryModelsController : ControllerBase
    {
        private readonly BookingContext _context;
        private readonly ILogger<CategoryModelsController> logger;


        public CategoryModelsController(BookingContext context, ILogger<CategoryModelsController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: api/CategoryModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategoryModel()
        {
            logger.LogInformation("Get all Categorys");
            logger.LogWarning("API couldn't handle request");
            return await _context.CategoryModel.ToListAsync();
        }

        // GET: api/CategoryModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryModel(int id)
        {
            logger.LogInformation("Get all Categorys by id");
            var categoryModel = await _context.CategoryModel.FindAsync(id);

            if (categoryModel == null)
            {
                logger.LogWarning("API couldn't handle request");
                return NotFound();
            }

            return categoryModel;
        }

        // PUT: api/CategoryModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryModel(int id, CategoryModel categoryModel)
        {
            logger.LogInformation("Updating Category by id");

            if (id != categoryModel.Id)
            {
                logger.LogWarning("API couldn't update database");
                return BadRequest();
            }

            _context.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
                {
                    logger.LogWarning("API couldn't update database");
                    return NotFound();
                }
                else
                {
                    logger.LogWarning("API couldn't update database");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CategoryModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> PostCategoryModel(CategoryModel categoryModel)
        {
            logger.LogInformation("A new Category was created");
            logger.LogWarning("API couldn't handle createing a new category request");
            _context.CategoryModel.Add(categoryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryModel", new { id = categoryModel.Id }, categoryModel);
        }

        // DELETE: api/CategoryModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryModel(int id)
        {
            logger.LogInformation("A new Category was deleted");
            var categoryModel = await _context.CategoryModel.FindAsync(id);
            if (categoryModel == null)
            {
                logger.LogWarning("API couldn't handle deleting a new category request");
                return NotFound();
            }

            _context.CategoryModel.Remove(categoryModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryModelExists(int id)
        {
            return _context.CategoryModel.Any(e => e.Id == id);
        }
       
    }
}
