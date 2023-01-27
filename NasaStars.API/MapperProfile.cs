using AutoMapper;
using NasaStars.DAL.Models;
using NasaStars.VM;

namespace NasaStars.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Star, StarVM>().ReverseMap();
        }
    }
}
