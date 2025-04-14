using CaseItau.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseItau.API.Infrastructure.Context
{
    public class FundoContext : DbContext
    {
        public FundoContext(DbContextOptions<FundoContext> options) : base(options) { }
        public DbSet<FundoEntity> Fundo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundoEntity>()
                .HasOne(f => f.TipoFundo)
                .WithMany()
                .HasForeignKey(f => f.CodigoTipo);
        }
    }
}
