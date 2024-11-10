
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet("GetTeam")]
        [MapToApiVersion("1.0")]
        public IActionResult GetV1()
        {
            return Ok("V1 Get to be implemented");
        }
        [HttpGet("GetTeam")]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
            return Ok("V2 Get to be implemented");
        }

    }
}
