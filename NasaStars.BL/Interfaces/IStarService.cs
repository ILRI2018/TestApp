namespace NasaStars.BL.Interfaces
{
    public interface IStarService
    {
        Task<List<string>> GetStars();
    }
}
