using Api_Exec_2.Model;

namespace Api_Exec_2.Repositories.Interface
{
    public interface IRepositoryConta<T> : IRepositoryService<T> where T : Conta
    {
    }
}
