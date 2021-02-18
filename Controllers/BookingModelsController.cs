using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingAPI.Models;

namespace BookingAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingModelsController : ControllerBase
    {
        private readonly BookingContext _context;

        public BookingModelsController(BookingContext context)
        {
            _context = context;
        }

        // GET: api/BookingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingModel()
        {
            return await _context.BookingModel.Include(x => x.Category).ToListAsync();
        }

        // GET: api/BookingModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBookingModel(int id)
        {
            var bookingModel = await _context.BookingModel.FindAsync(id);

            if (bookingModel == null)
            {
                return NotFound();
            }

            return bookingModel;
        }

        // PUT: api/BookingModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingModel(int id, BookingModel bookingModel)
        {
            if (id != bookingModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelExists(id))
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

        // POST: api/BookingModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingModel>> PostBookingModel(BookingModel bookingModel)
        {
            _context.BookingModel.Add(bookingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingModel", new { id = bookingModel.Id }, bookingModel);
        }

        // DELETE: api/BookingModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingModel(int id)
        {
            var bookingModel = await _context.BookingModel.FindAsync(id);
            if (bookingModel == null)
            {
                return NotFound();
            }

            _context.BookingModel.Remove(bookingModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingModelExists(int id)
        {
            return _context.BookingModel.Any(e => e.Id == id);
        }
    }
}
