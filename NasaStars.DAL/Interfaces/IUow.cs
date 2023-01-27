using NasaStars.DAL.Models;

namespace NasaStars.DAL.Interfaces
{
    public interface IUow: IDisposable
    {
        public IGenericRepository<Star> StarEntity { get; }

        public Task SaveAsync(CancellationToken cancellationToken = default);
    }

}
