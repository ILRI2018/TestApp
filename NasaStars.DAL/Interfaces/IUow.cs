namespace NasaStars.DAL.Interfaces
{
    internal interface IUow
    {
        public Task SaveAsync(CancellationToken cancellationToken = default);
    }

}
