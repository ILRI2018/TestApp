using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace NasaStars.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IQueryable<T> GetQueryable();
        Task<int> ExecuteQueryRawAsync(string query, IEnumerable<object> parameters, CancellationToken cancellationToken = default);
        Task<IList<T>> GetAsync(List<Expression<Func<T, bool>>> predicates,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = false, bool ignoreQueryFilters = false, CancellationToken cancellationToken = default);

    }
}
