
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RaceDay.Controllers
{
    [ApiController]
    [Route("api/secure")]
    public class SecureController : ControllerBase
    {
        // Any logged-in user can access this endpoint.
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok(new
            {
                message = "You are successfully authenticated."
            });
        }

        // Only participants can access this endpoint.
        [Authorize(Roles = "Participant")]
        [HttpGet("participant")]
        public IActionResult Participant()
        {
            return Ok(new
            {
                message = "Welcome, Participant!"
            });
        }

        // Only organisers can access this endpoint.
        [Authorize(Roles = "Organiser")]
        [HttpGet("organiser")]
        public IActionResult Organiser()
        {
            return Ok(new
            {
                message = "Welcome, Organiser!"
            });
        }
    }
}
