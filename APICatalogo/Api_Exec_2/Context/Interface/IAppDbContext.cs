using Api_Exec_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Exec_2.Context.Interface
{
    public interface IAppDbContext 
    {
        DbSet<Conta>? Contas { get; set; }
        DbSet<Contato>? Contatos { get; set; }
    }
}
