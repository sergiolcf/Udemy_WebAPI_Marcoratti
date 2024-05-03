using ApiExecUm.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiExecUm.Context.Interface
{
    public interface IAppDbContext
    {
        DbSet<Conta>? Contas { get; set; }
        DbSet<Contato>? Contatos { get; set; }
        DbSet<Endereco>? Enderecos { get; set; }
    }
}