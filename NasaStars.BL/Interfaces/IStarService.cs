using NasaStars.VM;

namespace NasaStars.BL.Interfaces
{
    public interface IStarService
    {
        Task GetStarsFromSite();
        Task RemoveAllFromTable();
        Task<StarResultVM> GetFilterStars(StarRequestVM starRequestVM);
        Task<List<int>> GetYears();
        Task<List<string>> GetClasses();
    }
}
