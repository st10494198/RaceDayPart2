
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using RaceDay.Data;

namespace RaceDay.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultsController : ControllerBase
    {
        private readonly RaceDayContext _db;

        public ResultsController(RaceDayContext db)
        {
            _db = db;
        }

        // Organiser can view all results
        [HttpGet]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> GetResults()
        {
            var results = await _db.Results.ToListAsync();
            return Ok(results);
        }

        // Participant can view their own results
        [HttpGet("my")]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> GetMyResults()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out int participantId))
                return Unauthorized();

            var results = await (
                from result in _db.Results
                join enrolment in _db.Enrolments
                    on result.EnrolmentID equals enrolment.EnrolmentID
                where enrolment.UserID == participantId
                select result
            ).ToListAsync();

            return Ok(results);
        }

        // Organiser can record a race result
        [HttpPost]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> CreateResult(Result result)
        {
            var enrolmentExists = await _db.Enrolments
                .AnyAsync(e => e.EnrolmentID == result.EnrolmentID);

            if (!enrolmentExists)
            {
                return BadRequest(new
                {
                    message = "Enrolment does not exist."
                });
            }

            if (result.Position < 1)
            {
                return BadRequest(new
                {
                    message = "Position must be at least 1."
                });
            }

            result.ResultID = 0;

            _db.Results.Add(result);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetResults),
                new { id = result.ResultID },
                result);
        }
    }
}
