using Microsoft.EntityFrameworkCore;
using NasaStars.DAL.Interfaces;
using System.Linq.Expressions;

namespace NasaStars.DAL.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
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
