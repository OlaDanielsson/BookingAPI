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
    public class RoomModelsController : ControllerBase
    {
        private readonly BookingContext _context;
        private readonly ILogger<RoomModelsController> logger;

        public RoomModelsController(BookingContext context, ILogger<RoomModelsController> logger)
        {
            _context = context;
            this.logger = logger;
        }


        // GET: api/RoomModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomModel>>> GetRoomModel()
        {
            logger.LogInformation("Get all Rooms");
            logger.LogWarning("API couldn't handle request");
            return await _context.RoomModel.ToListAsync(); // Det finns fel i kod
        }

        // GET: api/RoomModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetRoomModel(int id)
        {
            logger.LogInformation("Get all Rooms by id");
            var roomModel = await _context.RoomModel.FindAsync(id);

            if (roomModel == null)
            {
                logger.LogWarning("API couldn't handle get room by id request");
                return NotFound();
            }

            return roomModel;
        }

        // PUT: api/RoomModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomModel(int id, RoomModel roomModel)
        {
            logger.LogInformation("Update room by id");
            logger.LogWarning("API couldn't update room by id request");

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
                    logger.LogWarning("API couldn't update room by id request");
                    return NotFound();
                }
                else
                {
                    logger.LogWarning("API couldn't update room by id request");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoomModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomModel>> PostRoomModel(RoomModel roomModel)
        {
            logger.LogInformation("Create new room");
            logger.LogWarning("API couldn't create new room");
            _context.RoomModel.Add(roomModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomModel", new { id = roomModel.Id }, roomModel);
        }

        // DELETE: api/RoomModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomModel(int id)
        {
            logger.LogInformation("Deleted a room");
            var roomModel = await _context.RoomModel.FindAsync(id);
            if (roomModel == null)
            {
                logger.LogWarning("API couldn't delete room");
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
