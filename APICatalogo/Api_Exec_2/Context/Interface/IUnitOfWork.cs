using Api_Exec_2.Model;
using Api_Exec_2.Repositories.Interface;

namespace Api_Exec_2.Context.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepositoryConta<Conta> RepositoryConta { get; }
        IRepositoryContato<Contato> RepositoryContato { get; }
        void CommitAsync();
    }
}