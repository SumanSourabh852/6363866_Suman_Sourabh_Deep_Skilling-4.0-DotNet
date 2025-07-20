// For question 1

/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureDataController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetSecureData()
        {
            var username = User.Identity?.Name;
            return Ok(new { Message = $"Hello {username}, this is protected data." });
        }
    }
}
*/

// For question 2

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok("This is protected data.");
        }
    }
}
