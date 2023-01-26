using NasaStars.VM;

namespace NasaStars.BL.Interfaces
{
    public interface IStarService
    {
        Task<List<StarVM>> GetStars();
    }
}
