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
    public class BookingModelsController : ControllerBase
    {
        private readonly BookingContext _context;
        private readonly ILogger<BookingModelsController> logger;

        public BookingModelsController(BookingContext context, ILogger<BookingModelsController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: BookingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingModel()
        {
            logger.LogInformation("Get all bookings");
            logger.LogWarning("API couldn't handle request");
            return await _context.BookingModel.ToListAsync();
        }

        //// GET: api/BookingModels/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BookingModel>> GetBookingModel(int id)
        //{
        //    var bookingModel = await _context.BookingModel.FindAsync(id);

        //    if (bookingModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return bookingModel;
        //}
        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingsByGuestId(int id)
        {
            logger.LogInformation("Get all bookings by guest id");
            var bookings = await _context.BookingModel.Where(e => e.GuestId == id).ToListAsync();

            if (bookings.Count == 0)
            {
                logger.LogWarning("API couldn't handle request");
                return NotFound();
            }

            return bookings;
        }

        // PUT: api/BookingModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingModel(int id, BookingModel bookingModel)
        {
            logger.LogInformation("Updating booking by id");
            if (id != bookingModel.Id)
            {
                logger.LogWarning("API couldn't update database");
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

        // POST: api/BookingModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingModel>> PostBookingModel(BookingModel bookingModel)
        {
            logger.LogInformation("A new booking on seasharphotel was booked");
            logger.LogWarning("API couldn't handle booking a new room request");
            _context.BookingModel.Add(bookingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingModel", new { id = bookingModel.Id }, bookingModel);
        }

        // DELETE: api/BookingModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingModel(int id)
        {
            logger.LogInformation("A booking was deleted");
            var bookingModel = await _context.BookingModel.FindAsync(id);
            if (bookingModel == null)
            {
                logger.LogWarning("API couldn't handle deleting request");
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
