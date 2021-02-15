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
    public class RoomModelsController : ControllerBase
    {
        private readonly BookingContext _context;

        public RoomModelsController(BookingContext context)
        {
            _context = context;
        }

        // GET: RoomModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomModel>>> GetRoomModel()
        {
            return await _context.RoomModel.ToListAsync();
        }

        // GET: api/RoomModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetRoomModel(int id)
        {
            var roomModel = await _context.RoomModel.FindAsync(id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return roomModel;
        }

        // PUT: api/RoomModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomModel(int id, RoomModel roomModel)
        {
            if (id != roomModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomModelExists(id))
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

        // POST: apiRoomModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomModel>> PostRoomModel(RoomModel roomModel)
        {
            _context.RoomModel.Add(roomModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomModel", new { id = roomModel.Id }, roomModel);
        }

        // DELETE: api/RoomModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomModel(int id)
        {
            var roomModel = await _context.RoomModel.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }

            _context.RoomModel.Remove(roomModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomModelExists(int id)
        {
            return _context.RoomModel.Any(e => e.Id == id);
        }
    }
}
