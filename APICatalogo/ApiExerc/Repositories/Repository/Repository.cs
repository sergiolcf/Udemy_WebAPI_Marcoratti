using ApiExerc.Context;
using ApiExerc.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiExerc.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T? Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public T? Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public T? Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
    }
}