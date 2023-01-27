using AutoMapper;
using NasaStars.BL.Interfaces;
using NasaStars.DAL.Models;
using NasaStars.VM;
using Newtonsoft.Json;

namespace NasaStars.BL.Services
{
    public class StarService : IStarService
    {
        private readonly IHttpHelper _httpHelper;
        private readonly DAL.Interfaces.IUow _uow;
        private readonly IMapper _mapper;

        public StarService(IHttpHelper httpHelper, DAL.Interfaces.IUow uow, IMapper mapper)
        {
            _httpHelper = httpHelper;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<StarVM>> GetStars()
        {
            var result = await _httpHelper.GetAsync<List<StarVM>>("https://data.nasa.gov/resource/y77d-th95.json", null);
            var items = _mapper.Map<List<Star>>(result);

            //var xxx = await _uow.StarEntity.GetQueryable().InsertFromQueryAsync("StarService","dbo","Stars", x => new { items.First().Name });
            _uow.StarEntity.AddRange(items);
            await _uow.SaveAsync();
            /*x => new { x.Id, x.Name, x.Nametype, x.Recclass, x.Mass, x.Fall, x.Year, x.Reclat, x.Reclong }*/

            return result;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nametype { get; set; }
        public string Recclass { get; set; }
        public string Mass { get; set; }
        public string Fall { get; set; }
        public DateTime Year { get; set; }
        public decimal Reclat { get; set; }
        public decimal Reclong { get; set; }
        public GeolocationVM Geolocation { get; set; }

        [JsonProperty(":@computed_region_cbhk_fwbd")]
        public int ComputedRegionCbhkFwbd { get; set; }

        [JsonProperty(":@computed_region_nnqa_25f4")]
        public int ComputedRegionNnqa { get; set; }

    }
}
