using Microsoft.AspNetCore.Mvc;
using NasaStars.BL.Interfaces;

namespace NasaStars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {
        private readonly IStarService _starService;
        public StarController(IHttpHelper httpHelper, IStarService starService)
        {
            _starService = starService;
        }


        [HttpGet("stars")]
        public async Task<IActionResult> GetStars()
        {
            var xxx = await _starService.GetStars();

            return Ok(xxx);
        }
    }
}
