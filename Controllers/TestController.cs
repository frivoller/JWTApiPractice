using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok(new { message = "This endpoint is public." });
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult ProtectedEndpoint()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;

            return Ok(new
            {
                message = "Access granted to the protected endpoint.",
                userEmail = userEmail
            });
        }
    }
}