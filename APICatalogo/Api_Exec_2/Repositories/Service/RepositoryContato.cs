using Api_Exec_2.Context.Service;
using Api_Exec_2.Model;
using Api_Exec_2.Repositories.Interface;

namespace Api_Exec_2.Repositories.Service
{
    public class RepositoryContato<T> : RepositoryServices<T>, IRepositoryContato<T> where T : Contato
    {
        public RepositoryContato(AppDbContext context) : base(context)
        {
        }
    }
}