using Api_Exec_2.Context.Service;
using Api_Exec_2.Model;
using Api_Exec_2.Repositories.Interface;
using System.Linq.Expressions;

namespace Api_Exec_2.Repositories.Service
{
    public class RepositoryConta<T> : RepositoryServices<T>, IRepositoryConta<T> where T : Conta
    {
        public RepositoryConta(AppDbContext context) : base(context)
        {
        }
    }
}