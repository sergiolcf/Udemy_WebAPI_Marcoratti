using Api_Exec_2.Context.Interface;
using Api_Exec_2.Model;
using Api_Exec_2.Repositories.Interface;
using Api_Exec_2.Repositories.Service;

namespace Api_Exec_2.Context.Service
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        public AppDbContext _Context;

        private IRepositoryConta<Conta> _repositoryConta;

        private IRepositoryContato<Contato> _repositoryContato;
        public UnitOfWork(AppDbContext context)
        {
            _Context = context;
        }

        public IRepositoryConta<Conta> RepositoryConta
        {
            get
            {
                return _repositoryConta = _repositoryConta ?? new RepositoryConta<Conta>(_Context);
            }
        }

        public IRepositoryContato<Contato> RepositoryContato
        {
            get
            {
                return _repositoryContato = _repositoryContato ?? new RepositoryContato<Contato>(_Context);
            }
        }
        public async void CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}