using AutoMapper;
using Microsoft.Data.SqlClient;
using NasaStars.BL.Interfaces;
using NasaStars.DAL.Models;
using NasaStars.VM;
using System.Data;
using System.Linq.Expressions;

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

        public async Task RemoveAllFromTable()
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
                    new SqlParameter("Type", item.Type ?? Convert.DBNull),
                    new SqlParameter("Coordinates", item.Coordinates ?? Convert.DBNull),

                };
                await _uow.StarEntity.ExecuteQueryRawAsync("INSERT INTO Stars(Id, Name, NameType, Recclass, Mass, Fall, Year, Reclat, Reclong, ComputedRegionCbhkFwbd, ComputedRegionNnqa, Type, Coordinates) " +
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}, {12})", paramItems);
            }
        }

        public async Task<StarResultVM> GetFilterStars(StarRequestVM starRequestVM)
        {
            starRequestVM.From = new DateTime(2000, 1, 1);
            starRequestVM.To = new DateTime(2002, 1, 1);

            starRequestVM.Name = null;
            starRequestVM.Reclass = null;
            //starRequestVM.To = null;
            //starRequestVM.Reclass = "L5";

            var resultVM = new StarResultVM();
            var predicates = GetPredicates(starRequestVM);

            var itemStars = (await _uow.StarEntity.GetAsync(predicates, x => x.OrderByDescending(x => x.Year))).ToList();

            foreach (var itemStarGroup in itemStars.GroupBy(x => x.Year).OrderBy(x => x.Key))
            {
                var group = new StarGroupVM {
                        Year = itemStarGroup.Key.Value.Year,
                        TotalCount = itemStarGroup.Select(x => x).Count(),
                        TotalSumMass = (int)itemStarGroup.Sum(x => x.Mass),
                    };
                resultVM.GroupByYearStars.Add(itemStarGroup.Key.Value.Year, group);
            }

            return resultVM;
        }

        private List<Expression<Func<Star, bool>>> GetPredicates(StarRequestVM starRequestVM)
        {
            List<Expression<Func<Star, bool>>> predicates = new List<Expression<Func<Star, bool>>>();

            if (starRequestVM.From.HasValue && starRequestVM.To.HasValue)
            {
                predicates.Add(x => x.Year.Value.Year >= starRequestVM.From.Value.Year && x.Year.Value.Year <= starRequestVM.To.Value.Year);
            }
            if (!string.IsNullOrEmpty(starRequestVM.Reclass))
            {
                predicates.Add(x => x.Recclass == starRequestVM.Reclass);
            }
            if (!string.IsNullOrEmpty(starRequestVM.Name))
            {
                predicates.Add(x => x.Name.Contains(starRequestVM.Name));
            }
            return predicates;
        }
    }
}
