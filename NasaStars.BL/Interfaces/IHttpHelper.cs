namespace NasaStars.BL.Interfaces
{
    public interface IHttpHelper
    {
        Task<T> GetAsync<T>(string query, string externalAccessToken = null, CancellationToken token = default);
    }
}
