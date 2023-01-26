using Microsoft.AspNetCore.Mvc;
using NasaStars.BL.Interfaces;

namespace NasaStars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {
        private readonly IHttpHelper _httpHelper;

        public StarController(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async IActionResult GetStars()
        {

        }
    }
}
