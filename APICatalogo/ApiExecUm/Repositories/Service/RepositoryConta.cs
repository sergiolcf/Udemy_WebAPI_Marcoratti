using ApiExecUm.Context.Services;
using ApiExecUm.Model;
using ApiExecUm.Repositories.Interface;
using System.Linq.Expressions;

namespace ApiExecUm.Repositories.Service
{
    public class RepositoryConta<T> : RepositoryServices<Conta>, IRepositoryConta<T> where T : Conta
    {
        public RepositoryConta(AppDbContext context) : base(context)
        {
        }
        public T? GetByCNPJ(Expression<Func<Conta, bool>> predicate)
        {
            return _context.Contas?.FirstOrDefault(predicate) as T;
        }
    }
}
