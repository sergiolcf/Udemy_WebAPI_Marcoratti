using ApiExecUm.Context.Interface;
using ApiExecUm.Context.Services;
using ApiExecUm.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiExecUm.Repositories.Service
{
    public class RepositoryServices<T> : IRepositoryServices<T> where T : class
    {
        protected AppDbContext _context;
        public RepositoryServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T>? GetAll()
        {
            return _context.Set<T>().AsNoTracking<T>().ToList<T>();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }
        public async Task<T>? GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public T? Create(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }
        public T? Update(T entity)
        {
            return _context.Set<T>().Update(entity).Entity;
        }
        public T? Delete(T entity)
        {
            return _context.Set<T>().Remove(entity).Entity;
        }

    }
}