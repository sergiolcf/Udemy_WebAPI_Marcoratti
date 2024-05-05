using ApiExecUm.Model;
using System.Linq.Expressions;

namespace ApiExecUm.Repositories.Interface
{
    public interface IRepositoryContato<T> : IRepositoryServices<Contato>
    {
        T? GetByCPF(Expression<Func<Contato, bool>> predicate);
        IEnumerable<T>? GetByCidade(Expression<Func<Contato, bool>> predicate);
    }
}
