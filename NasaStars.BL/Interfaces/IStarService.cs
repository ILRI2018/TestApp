using NasaStars.VM;

namespace NasaStars.BL.Interfaces
{
    public interface IStarService
    {
        Task GetStarsFromSite();
        Task RemoveAll();
    }
}
