using Api_Exec_2.Context.Service;
using Api_Exec_2.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api_Exec_2.Repositories.Service
{
    public class RepositoryServices<T> : IRepositoryService<T> where T : class
    {
        protected AppDbContext _context;

        public RepositoryServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>>? GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T>? Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<T>? Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T? Update(T entity)
        {
            return _context.Update(entity).Entity;

        }

        public T? Delete(T entity)
        {
            return _context.Set<T>().Remove(entity).Entity;
        }
    }
}