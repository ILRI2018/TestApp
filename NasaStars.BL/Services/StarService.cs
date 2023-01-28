using AutoMapper;
using Microsoft.Data.SqlClient;
using NasaStars.BL.Interfaces;
using NasaStars.DAL;
using NasaStars.DAL.Models;
using NasaStars.VM;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;

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
            //_uow.StarEntity.AddRange(items);

            //     public int ComputedRegionCbhkFwbd { get; set; }

            //public int ComputedRegionNnqa { get; set; }

            foreach (var item in items)
            {
                List<SqlParameter> paramItems = new List<SqlParameter>
                {
                    new SqlParameter("Id", item.Id),
                    new SqlParameter("Name", item.Name),
                    new SqlParameter("Nametype", item.Nametype),
                    new SqlParameter("Recclass", item.Recclass),
                    new SqlParameter("Mass", item.Mass),
                    new SqlParameter("Fall", item.Fall),
                    new SqlParameter("Year", item.Year),
                    new SqlParameter("Reclat", item.Reclat),
                    new SqlParameter("Reclong", item.Reclong),
                    new SqlParameter("ComputedRegionCbhkFwbd", item.ComputedRegionCbhkFwbd),
                    new SqlParameter("ComputedRegionNnqa", item.ComputedRegionNnqa),
                };
                await _uow.StarEntity.ExecuteQueryRawAsync("INSERT INTO Stars(Id, Name, NameType, Recclass, Mass, Fall, Year, Reclat, Reclong, ComputedRegionCbhkFwbd, ComputedRegionNnqa) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})", paramItems);
            }

            //await _uow.SaveAsync();
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
