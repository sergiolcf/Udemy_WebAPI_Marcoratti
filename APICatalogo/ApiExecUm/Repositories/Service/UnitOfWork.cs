using ApiExecUm.Context.Services;
using ApiExecUm.Model;
using ApiExecUm.Repositories.Interface;

namespace ApiExecUm.Repositories.Service
{
    /// <summary>
    /// Responsavel por persistir as mudanças no banco e também descartar da memoria o que não esta sendo utilizado
    /// </summary>
    /// <typeparam name="T">Tipo de entidade manipulada pelo repositório</typeparam>
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IRepositoryConta<T>? _repositoryConta;

        private IRepositoryContato<T>? _repositoryContato;

        public AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepositoryConta<T> RepositoryConta
        {
            get
            {
                return _repositoryConta = _repositoryConta ?? new RepositoryConta<Conta>(_context) as IRepositoryConta<T>;
            }
        }

        public IRepositoryContato<T> RepositoryContato
        {
            get
            {
                return _repositoryContato = _repositoryContato ?? new RepositoryContato<Contato>(_context) as IRepositoryContato<T>;
            }
        }

        /// <summary>
        /// Persistir as mudanças no banco de dados
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }
        /// <summary>
        /// Descartar uso de memória não utilizado
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
