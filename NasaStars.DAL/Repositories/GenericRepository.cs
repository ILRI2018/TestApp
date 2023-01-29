using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NasaStars.DAL.Interfaces;
using System.Linq.Expressions;

namespace NasaStars.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly NasaStarsContext _context;
        private readonly DbSet<T> _dataSet;

        public GenericRepository(NasaStarsContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dataSet.AddRange(entities);
        }

        public Task<int> ExecuteQueryRawAsync(string query, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {

            return _context.Database.ExecuteSqlRawAsync(query, parameters, cancellationToken);
        }

        public async Task<IList<T>> GetAsync(List<Expression<Func<T, bool>>> predicates,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = false, bool ignoreQueryFilters = false, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dataSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }
            else
            {
                return await query.ToListAsync(cancellationToken);
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dataSet.Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dataSet.ToList();
        }

        public T GetById(Guid id)
        {
            return _dataSet.Find(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dataSet.AsQueryable<T>();
        }

        public void Remove(T entity)
        {
            _dataSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dataSet.RemoveRange(entities);
        }

    }
}
