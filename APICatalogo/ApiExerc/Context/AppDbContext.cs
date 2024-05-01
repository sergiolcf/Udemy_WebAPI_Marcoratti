using ApiExerc.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiExerc.Context
{
    public class AppDbContext : DbContext
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
                .HasMany(c => c.Contato) // Uma conta pode ter muitos contatos
                .WithOne(c => c.Conta)   // Cada contato pertence a uma única conta
                .HasForeignKey(c => c.Id); // Chave estrangeira em Contato referenciando Conta
        }
    }

}
