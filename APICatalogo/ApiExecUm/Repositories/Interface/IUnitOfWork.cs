namespace ApiExecUm.Repositories.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepositoryConta<T> RepositoryConta { get; }
        IRepositoryContato<T> RepositoryContato { get; }

        void Commit();
        void Dispose();
    }
}
