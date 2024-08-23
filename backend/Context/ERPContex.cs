using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class ERPContext : DbContext, IERPContext
    {
        public DbSet<Clients> Clients { get; set; } = null!;

        public ERPContext(DbContextOptions<ERPContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=App;User=Sa;Password=SqlServer123!;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}