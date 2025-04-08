using CaseItau.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseItau.API.Infrastructure.Context
{
    public class FundoContext : DbContext
    {
        public FundoContext(DbContextOptions<FundoContext> options) : base(options) { }
        public DbSet<FundoEntity> Fundo { get; set; }
    }
}
