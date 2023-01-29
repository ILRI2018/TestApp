using Microsoft.AspNetCore.Mvc;
using NasaStars.BL.Interfaces;
using NasaStars.VM;

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
        [HttpGet("get-stars-from-site")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 10)]
        public async Task<IActionResult> GetStars()
        {
            await _starService.RemoveAllFromTable();
            await _starService.GetStarsFromSite();

            return Ok();
        }

        [HttpPost("get-stars-filter")]
        public async Task<IActionResult> GetFilterStars(StarRequestVM starRequestVM)
        {
            var items  = await _starService.GetFilterStars(starRequestVM);

            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }
    }
}
