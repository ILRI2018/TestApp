using AutoMapper;
using NasaStars.DAL.Models;
using NasaStars.VM;

namespace NasaStars.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Star, StarVM>();
            CreateMap<StarVM, Star>().AfterMap((src, dest) => dest.Type = src.Geolocation.Type)
                .AfterMap((src, dest) => dest.Coordinates = src.Geolocation.Coordinates == null ? string.Empty : string.Join(',', src.Geolocation.Coordinates.Select(x => x.ToString())));
            CreateMap<Geolocation, GeolocationVM>().ReverseMap();
        }
    }
}
