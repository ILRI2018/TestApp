using NasaStars.BL.Interfaces;
using NasaStars.VM;

namespace NasaStars.BL.Services
{
    public class StarService : IStarService
    {
        private readonly IHttpHelper _httpHelper;
        private readonly DAL.Interfaces.IUow _uow;

        public StarService(IHttpHelper httpHelper, DAL.Interfaces.IUow uow)
        {
            _httpHelper = httpHelper;
            _uow = uow;
        }

        public async Task<List<StarVM>> GetStars()
        {
            var result = await _httpHelper.GetAsync<List<StarVM>>("https://data.nasa.gov/resource/y77d-th956.json", null);

            await _uow.StarEntity.GetQueryable().InsertFromQueryAsync("Stars", x => new { x.Id });

            return result;
        }

        //private async Task<string> SaveListStars(List<StarVM> starList)
        //{

        //}
    }
}
