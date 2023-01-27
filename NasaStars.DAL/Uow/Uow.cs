using NasaStars.DAL.Interfaces;
using NasaStars.DAL.Models;
using NasaStars.DAL.Repositories;

namespace NasaStars.DAL.Uow
{
    public class Uow : IUow
    {
        private readonly NasaStarsContext _context;

        private IGenericRepository<Star> _starEntity;


        private bool disposedValue;

        public Uow(NasaStarsContext context)
        {
            _context = context;
        }

        public IGenericRepository<Star> StarEntity => _starEntity ??= new GenericRepository<Star>(_context);


        public Task SaveAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                return;
            }

            if (disposing)
                _context?.Dispose();

            disposedValue = true;
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
