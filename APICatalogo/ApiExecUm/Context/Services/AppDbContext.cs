using ApiExecUm.Context.Interface;
using ApiExecUm.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiExecUm.Context.Services
{
    public class AppDbContext : DbContext/*, IAppDbContext*/
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Conta>? Contas { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                .HasMany(c => c.ContatoList)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.ContaID)
                .IsRequired(false); // A chave estrangeira é opcional

            modelBuilder.Entity<Conta>()
                .HasOne(c => c.ContatoPrimario)
                .WithMany()
                .HasForeignKey(c => c.ContatoPrimarioId)
                .IsRequired(false); // A chave estrangeira é opcional
        }

    }
}