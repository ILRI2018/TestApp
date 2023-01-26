using NasaStars.BL.Interfaces;
using NasaStars.VM;

namespace NasaStars.BL.Services
{
    public class StarService : IStarService
    {
        private readonly IHttpHelper _httpHelper;

        public StarService(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<List<StarVM>> GetStars()
        {
            var result = await _httpHelper.GetAsync<List<StarVM>>("https://data.nasa.gov/resource/y77d-th95.json", null);

            return result;
        }
    }
}
