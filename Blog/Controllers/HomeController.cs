using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("health-check")]
        public IActionResult Get([FromServices] IConfiguration config) 
        {
            var env = config.GetSection("Environment").Value;
            return Ok(new { env });
        }
    }
}
