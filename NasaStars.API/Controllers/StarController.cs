using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NasaStars.BL.Interfaces;
using NasaStars.VM;

namespace NasaStars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
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

            try
            {
                await _starService.GetStarsFromSite();
            }
            catch
            {
                return BadRequest("error retrieving data");
            }

            return Ok();
        }

        /// <summary>
        ///  Get filter stars
        /// </summary>
        /// <returns></returns>
        [HttpPost("get-stars-filter")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 5)]
        public async Task<IActionResult> GetFilterStars(StarRequestVM starRequestVM)
        {
            var items  = await _starService.GetFilterStars(starRequestVM);

            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        /// <summary>
        ///  Get years
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-years")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 300)]
        public async Task<IActionResult> GetYears()
        {
            var years = await _starService.GetYears();
            if (years == null)
            {
                return NotFound();
            }
            return Ok(new YearResultVM { Years = years });
        }

        /// <summary>
        ///  Get classes
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-classes")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 300)]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await _starService.GetClasses();
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(new ClassResultVM { Classes = classes });
        }
    }
}
