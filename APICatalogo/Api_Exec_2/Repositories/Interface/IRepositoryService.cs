using System.Linq.Expressions;

namespace Api_Exec_2.Repositories.Interface
{
    public  interface IRepositoryService<T> where T : class
    {
         Task<List<T>>? GetAll();
        Task<T>? Get(Expression<Func<T, bool>> predicate);
        Task<T>? Create(T entity);
         T? Update(T entity);
         T? Delete(T entity);
    }
}