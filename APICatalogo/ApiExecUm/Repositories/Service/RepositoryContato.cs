using ApiExecUm.Context.Services;
using ApiExecUm.Model;
using ApiExecUm.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiExecUm.Repositories.Service
{
    public class RepositoryContato<T> : RepositoryServices<Contato>, IRepositoryContato<T> where T : Contato
    {
        public RepositoryContato(AppDbContext context) : base(context)
        {
        }

        public T? GetByCPF(Expression<Func<Contato, bool>> predicate)
        {
            return _context.Contatos?.FirstOrDefault(predicate) as T;
        }

        public IEnumerable<T>? GetByCidade(Expression<Func<Contato, bool>> predicate)
        {
            return (IEnumerable<T>?)(_context.Contatos?.Where(predicate).ToList());
        }
    }
}
