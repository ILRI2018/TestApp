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

        /// <summary>
        ///  Get start from nasa site
        /// </summary>
        /// <returns></returns>
        [HttpGet("stars")]
        public async Task<IActionResult> GetStars()
        {
            var result = await _starService.GetStars();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
