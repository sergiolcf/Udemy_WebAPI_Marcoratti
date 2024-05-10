using Api_Exec_2.Context.Interface;
using Api_Exec_2.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Exec_2.Context.Service
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Conta>? Contas { get; set; }
        public DbSet<Contato>? Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                .HasMany(c => c.ListaContatos)
                .WithOne(c => c.Conta)
                .HasForeignKey(c => c.ContaId)
                .IsRequired(false); // A chave estrangeira é opcional

            modelBuilder.Entity<Conta>()
                .HasOne(c => c.ContatoPrimario)
                .WithOne()
                .HasForeignKey<Conta>(c => c.ContatoPrimarioId)
                .IsRequired(false); // A chave estrangeira é opcional
        }
    }
}