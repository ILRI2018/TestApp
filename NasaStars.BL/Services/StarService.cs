using AutoMapper;
using Microsoft.Data.SqlClient;
using NasaStars.BL.Interfaces;
using NasaStars.DAL.Models;
using NasaStars.VM;
using System.Data;
using System.Net.Http.Headers;

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

        public async Task RemoveAll()
        {
            await _uow.StarEntity.ExecuteQueryRawAsync("DELETE FROM Stars", new object[1]);
        }

        public async Task GetStarsFromSite()
        {
            var result = await _httpHelper.GetAsync<List<StarVM>>("https://data.nasa.gov/resource/y77d-th95.json", null);
            var items = _mapper.Map<List<Star>>(result);
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
               InsertToDataBase(item);
            }
        }

        async private void InsertToDataBase(Star item)
        {
            object[] paramItems = new object[]
               {
                    new SqlParameter("Id", item.Id),
                    new SqlParameter("Name", item.Name),
                    new SqlParameter("Nametype", item.Nametype),
                    new SqlParameter("Recclass", item.Recclass),
                    new SqlParameter("Mass", item.Mass),
                    new SqlParameter("Fall", item.Fall),
                    new SqlParameter
                    {
                        ParameterName = "Year",
                        Value =  item.Year ?? Convert.DBNull,
                        SqlDbType = SqlDbType.DateTime2,
                    },
                    new SqlParameter("Reclat", item.Reclat),
                    new SqlParameter("Reclong", item.Reclong),
                    new SqlParameter("ComputedRegionCbhkFwbd", item.ComputedRegionCbhkFwbd),
                    new SqlParameter("ComputedRegionNnqa", item.ComputedRegionNnqa),
                    new SqlParameter("Type", item.Type),
                    new SqlParameter("Coordinates", item.Coordinates)
               };

            await _uow.StarEntity.ExecuteQueryRawAsync("INSERT INTO " +
            "Stars(Id, Name, NameType, Recclass, Mass, Fall, Year, Reclat, Reclong, ComputedRegionCbhkFwbd, ComputedRegionNnqa)" +
            " VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})", paramItems);
        }
    }
}
