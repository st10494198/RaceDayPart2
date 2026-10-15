
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using RaceDay.Data;

namespace RaceDay.Controllers
{
    [ApiController]
    [Route("api/enrolments")]
    [Authorize(Roles = "Organiser,Participant")]
    public class EnrolmentsController : ControllerBase
    {
        private readonly RaceDayContext _db;

        public EnrolmentsController(RaceDayContext db)
        {
            _db = db;
        }

        // GET: api/enrolments
        // Organisers can view all enrolments
        [HttpGet]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> GetEnrolments()
        {
            var enrolments = await _db.Enrolments.ToListAsync();
            return Ok(enrolments);
        }

        // GET: api/enrolments/my
        // Participants can view their own enrolments
        [HttpGet("my")]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> GetMyEnrolments()
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out int participantId))
                return Unauthorized();

            var enrolments = await _db.Enrolments
                .Where(e => e.UserID == participantId)
                .ToListAsync();

            return Ok(enrolments);
        }

        // GET: api/enrolments/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEnrolment(int id)
        {
            var enrolment = await _db.Enrolments.FindAsync(id);

            if (enrolment == null)
                return NotFound(new
                {
                    message = "Enrolment not found."
                });

            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (User.IsInRole("Participant") &&
                enrolment.UserID.ToString() != userId)
            {
                return Forbid();
            }

            return Ok(enrolment);
        }

        // POST: api/enrolments
        [HttpPost]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> CreateEnrolment(
            Enrolment enrolment)
        {
            var userId = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out int participantId))
                return Unauthorized();

            var categoryExists = await _db.Categories
                .AnyAsync(c =>
                    c.CategoryID == enrolment.CategoryID);

            if (!categoryExists)
                return BadRequest(new
                {
                    message = "Category does not exist."
                });

            enrolment.EnrolmentID = 0;
            enrolment.UserID = participantId;
            enrolment.EnrolmentDate = DateTime.Now;

            _db.Enrolments.Add(enrolment);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEnrolment),
                new { id = enrolment.EnrolmentID },
                enrolment);
        }

        // GET: api/events/1/enrolments
        // Organisers can view enrolments for an event
        [HttpGet("~/api/events/{eventId:int}/enrolments")]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> GetEventEnrolments(
            int eventId)
        {
            var eventExists = await _db.Events
                .AnyAsync(e => e.EventID == eventId);

            if (!eventExists)
                return NotFound(new
                {
                    message = "Event not found."
                });

            var enrolments = await (
                from enrolment in _db.Enrolments
                join category in _db.Categories
                    on enrolment.CategoryID
                    equals category.CategoryID
                where category.EventID == eventId
                select enrolment
            ).ToListAsync();

            return Ok(enrolments);
        }

        // DELETE: api/enrolments/1
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> DeleteEnrolment(int id)
        {
            var enrolment = await _db.Enrolments.FindAsync(id);

            if (enrolment == null)
                return NotFound(new
                {
                    message = "Enrolment not found."
                });

            _db.Enrolments.Remove(enrolment);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
