using NasaStars.BL.Interfaces;

namespace NasaStars.BL.Services
{
    public class StarService : IStarService
    {
        private readonly IHttpHelper _httpHelper;

        public StarService(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public Task<List<string>> GetStars()
        {
            var result = _httpHelper.GetAsync<List<string>>("https://data.nasa.gov/resource/y77d-th95.json", null);

            return result;
        }
    }
}
