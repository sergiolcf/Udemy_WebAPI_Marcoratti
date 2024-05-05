using ApiExecUm.Model;
using System.Linq.Expressions;

namespace ApiExecUm.Repositories.Interface
{
    public interface IRepositoryConta<T> : IRepositoryServices<Conta> 
    {
        T? GetByCNPJ(Expression<Func<Conta, bool>> predicate);
    }
}
