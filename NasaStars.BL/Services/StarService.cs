using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<int>> GetYears()
        {
            var listYears = await _uow.StarEntity.GetQueryable().Where(x => x.Year != null).Select(y => y.Year.Value.Year).Distinct().ToListAsync();
            return listYears;
        }

        public async Task<List<string>> GetClasses()
        {
            var listClasses = await _uow.StarEntity.GetQueryable().Where(x => x.Year != null).Select(y => y.Recclass).Distinct().ToListAsync();
            return listClasses;
        }

        public async Task GetStarsFromSite()
        {
            var result = await _httpHelper.GetAsync<List<StarVM>>("https://data.nasa.gov/resource/y77d-th95.json", null);

            var items = _mapper.Map<List<Star>>(result);

           _uow.StarEntity.AddRange(items);
           await _uow.SaveAsync();
        }

        public async Task<StarResultVM> GetFilterStars(StarRequestVM starRequestVM)
        {
            var resultVM = new StarResultVM();
            var predicates = GetPredicates(starRequestVM);

            var itemStars = (await _uow.StarEntity.GetAsync(predicates, x => x.OrderByDescending(x => x.Year))).ToList();

            int idGroup = 0;
            foreach (var itemStarGroup in itemStars.Where(x => x.Year != null).GroupBy(x => x.Year).OrderBy(x => x.Key))
            {
                var group = new StarGroupVM
                {
                    Id = ++idGroup,
                    Year = itemStarGroup.Key.Value.Year,
                    TotalCount = itemStarGroup.Select(x => x).Count(),
                    TotalSumMass = itemStarGroup.Sum(x => x.Mass),
                };
                resultVM.GroupByYearStars.Add(itemStarGroup.Key.Value.Year, group);
                resultVM.StarGroupVMs.Add(group);
            }
            resultVM.TotalMass = resultVM.GroupByYearStars.Select(x => x.Value).Sum(x => x.TotalSumMass);
            resultVM.Total = resultVM.GroupByYearStars.Select(x => x.Value).Sum(x => x.TotalCount);

            return resultVM;
        }

        private List<Expression<Func<Star, bool>>> GetPredicates(StarRequestVM starRequestVM)
        {
            List<Expression<Func<Star, bool>>> predicates = new List<Expression<Func<Star, bool>>>();

            if (starRequestVM.From.HasValue && starRequestVM.To.HasValue)
            {
                predicates.Add(x => x.Year.Value.Year >= starRequestVM.From.Value && x.Year.Value.Year <= starRequestVM.To.Value);
            }
            if (!string.IsNullOrEmpty(starRequestVM.Reclass))
            {
                predicates.Add(x => x.Recclass == starRequestVM.Reclass);
            }
            if (!string.IsNullOrEmpty(starRequestVM.Name))
            {
                predicates.Add(x => x.Name.ToLower().Contains(starRequestVM.Name.ToLower()));
            }
            return predicates;
        }
    }
}
