using ApiExecUm.Context.Interface;
using ApiExecUm.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiExecUm.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Conta>? Contas { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                .HasMany(c => c.ContatoList) // Uma conta pode ter muitos contatos
                .WithOne(c => c.Empresa)   // Cada contato pertence a uma única conta
                .HasForeignKey(c => c.Id); // Chave estrangeira em Contato referenciando Conta
        }
    }
}
