
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RaceDay.Data;

namespace RaceDay.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly RaceDayContext _db;

        public EventsController(RaceDayContext db)
        {
            _db = db;
        }

        // GET: api/events
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _db.Events.ToListAsync();
            return Ok(events);
        }

        // GET: api/events/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var eventItem = await _db.Events.FindAsync(id);

            if (eventItem == null)
                return NotFound(new { message = "Event not found." });

            return Ok(eventItem);
        }

        // POST: api/events
        [Authorize(Roles = "Organiser")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event eventItem)
        {
            eventItem.EventID = 0;

            _db.Events.Add(eventItem);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEvent),
                new { id = eventItem.EventID },
                eventItem);
        }

        // PUT: api/events/1
        [Authorize(Roles = "Organiser")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEvent(int id, Event updatedEvent)
        {
            if (id != updatedEvent.EventID)
                return BadRequest(new { message = "Event ID does not match." });

            var existingEvent = await _db.Events.FindAsync(id);

            if (existingEvent == null)
                return NotFound(new { message = "Event not found." });

            existingEvent.EventName = updatedEvent.EventName;
            existingEvent.EventDate = updatedEvent.EventDate;
            existingEvent.Location = updatedEvent.Location;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.OrganiserID = updatedEvent.OrganiserID;

            await _db.SaveChangesAsync();

            return Ok(existingEvent);
        }

        // DELETE: api/events/1
        [Authorize(Roles = "Organiser")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await _db.Events.FindAsync(id);

            if (eventItem == null)
                return NotFound(new { message = "Event not found." });

            _db.Events.Remove(eventItem);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
